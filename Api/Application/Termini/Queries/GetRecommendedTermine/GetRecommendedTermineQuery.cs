using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Application.Termini.Queries.GetTermineWithPagination;
using SportskiCentarRS2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Termini.Queries.GetRecommendedTermine
{
    public class GetRecommendedTermineQuery : IRequest<List<TerminDto>>
    {

    }
    public class GetRecommendedTermineQueryHandler : IRequestHandler<GetRecommendedTermineQuery, List<TerminDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        private static MLContext mlContextAkoImaRezervacija = null;
        private static ITransformer modelAkoImaRezervacija = null;

        public GetRecommendedTermineQueryHandler(IApplicationDbContext applicationDbContext,ICurrentUserService currentUserService, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }
        public async Task<List<TerminDto>> Handle(GetRecommendedTermineQuery request, CancellationToken cancellationToken)
        {
            if(await _applicationDbContext.Rezervacije.AnyAsync(x=>x.KorisnikId == _currentUserService.UserId, cancellationToken))
            {
                if (mlContextAkoImaRezervacija == null)
                {
                    mlContextAkoImaRezervacija = new MLContext();

                    var tmpData = await _applicationDbContext.Rezervacije.Where(x=>x.KorisnikId==_currentUserService.UserId).Include(x=>x.Termin).ToListAsync(cancellationToken);
                    var data = new List<KorisnikProstorijaModel>();
                    foreach (var rezervacija in tmpData)
                    {
                        data.Add(new KorisnikProstorijaModel { KorisnikId = _currentUserService.UserId, ProstorijaId = rezervacija.Termin.ProstorijaId });
                    }
                    var trainingDataView = mlContextAkoImaRezervacija.Data.LoadFromEnumerable(data);

                    var dataProcessingPipeline = mlContextAkoImaRezervacija.Transforms.Conversion.MapValueToKey(outputColumnName: "KorisnikIdEncoded", inputColumnName: nameof(KorisnikProstorijaModel.KorisnikId))
                                                .Append(mlContextAkoImaRezervacija.Transforms.Conversion.MapValueToKey(outputColumnName: "ProstorijaIdEncoded", inputColumnName: nameof(KorisnikProstorijaModel.ProstorijaId)));

                    //Specify the options for MatrixFactorization trainer
                    MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
                    options.MatrixColumnIndexColumnName = "KorisnikIdEncoded";
                    options.MatrixRowIndexColumnName = "ProstorijaIdEncoded";
                    options.LabelColumnName = "Label";
                    options.NumberOfIterations = 20;
                    options.ApproximationRank = 100;

                    //STEP 4: Create the training pipeline
                    var trainingPipeLine = dataProcessingPipeline.Append(mlContextAkoImaRezervacija.Recommendation().Trainers.MatrixFactorization(options));

                    modelAkoImaRezervacija = trainingPipeLine.Fit(trainingDataView);
                }

                var allItems = await _applicationDbContext.Termini.Include(x=>x.Prostorija).ToListAsync(cancellationToken);

                var predictionResult = new List<(Termin, float)>();

                foreach (var item in allItems)
                {
                    var predictionEngine =
                        mlContextAkoImaRezervacija.Model.CreatePredictionEngine<KorisnikProstorijaModel, VjerovatnocaRezervacije>(modelAkoImaRezervacija);

                    var prediction = predictionEngine.Predict(new KorisnikProstorijaModel()
                    {
                        KorisnikId = _currentUserService.UserId,
                        ProstorijaId = item.ProstorijaId
                    });

                    predictionResult.Add(new(item, prediction.Score));
                }

                var finalResult = predictionResult.OrderByDescending(x => x.Item2)
                    .Select(x => x.Item1).ToList();

                return _mapper.Map<List<TerminDto>>(finalResult);
            }
            else
            {
                var result = new List<TerminDto>();
                var rezervacijaPoProstoriji = await _applicationDbContext.Rezervacije.GroupBy(x => x.Termin.ProstorijaId).Select(x => new { ProstorijaId = x.Key, Count = x.Count() }).OrderBy(x=>x.Count).ToListAsync(cancellationToken);
                
                foreach(var prostorija in rezervacijaPoProstoriji)
                {
                    var terminiProstorje = await _applicationDbContext.Termini.Where(x => x.Slobodan == true && x.Pocetak >= DateTime.Now && x.ProstorijaId == prostorija.ProstorijaId)
                        .ProjectTo<TerminDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
                    result.AddRange(terminiProstorje);
                }
                result.AddRange(await _applicationDbContext.Termini.Where(x => !result.Select(w => w.Id).Contains(x.Id))
                    .ProjectTo<TerminDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken));
                return result;
            }
        }
        public class VjerovatnocaRezervacije
        {
            public float Score { get; set; }
        }
        public class KorisnikProstorijaModel
        {
            public int KorisnikId { get; set; }
            public int ProstorijaId { get; set; }
            public float Label { get; set; }
        }
    }
}
