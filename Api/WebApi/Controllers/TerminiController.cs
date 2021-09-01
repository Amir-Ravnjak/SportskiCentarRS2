using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportskiCentarRS2.Application.HelperModels;
using SportskiCentarRS2.Application.Termini.Commands.CreateTermin;
using SportskiCentarRS2.Application.Termini.Commands.DeleteTermin;
using SportskiCentarRS2.Application.Termini.Commands.UpdateTermin;
using SportskiCentarRS2.Application.Termini.Queries.GetRecommendedTermine;
using SportskiCentarRS2.Application.Termini.Queries.GetTerminById;
using SportskiCentarRS2.Application.Termini.Queries.GetTermineWithPagination;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.WebApi.Controllers
{
    [Authorize]
    public class TerminiController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<TerminDto>>> GetWithPagination([FromQuery]GetTermineWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await Mediator.Send(request, cancellationToken);
        }
        [HttpGet("recommended")]
        public async Task<ActionResult<List<TerminDto>>> GetRecommended(CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetRecommendedTermineQuery(), cancellationToken);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TerminVM>> GetById([FromRoute] int id, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetTerminByIdQuery { Id = id }, cancellationToken);
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateTerminCommand command, CancellationToken cancellationToken)
        {
            return await Mediator.Send(command, cancellationToken);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateTerminCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
                return BadRequest();

            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteTerminCommmand { Id = id }, cancellationToken);
            return NoContent();
        }
    }
}
