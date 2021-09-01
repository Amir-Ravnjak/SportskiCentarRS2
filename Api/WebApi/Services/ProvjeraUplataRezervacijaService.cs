using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SportskiCentarRS2.Application.Common.Interfaces;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.WebApi.Services
{
    public class ProvjeraUplataRezervacijaService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public ProvjeraUplataRezervacijaService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var applicationDbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
                    var rezervacijeProsloVrijemeNisuUplacene = await applicationDbContext.Rezervacije.Where(x => x.Termin.Pocetak < DateTime.Now && x.Uplata==null).ToListAsync(stoppingToken);
                    if (rezervacijeProsloVrijemeNisuUplacene.Any())
                    {
                        //TODO
                        //daj korisniku minus, nakon 3 minusa zabrani mu rezervisanje na 3 mjeseca
                    }
                    await Task.Delay(TimeSpan.FromMilliseconds(10), stoppingToken);
                }
            }
        }
    }
}
