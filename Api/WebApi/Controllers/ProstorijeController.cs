using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportskiCentarRS2.Application.Prostorije.Commands.CreateProstoriju;
using SportskiCentarRS2.Application.Prostorije.Commands.DeleteProstoriju;
using SportskiCentarRS2.Application.Prostorije.Commands.UpdateProstoriju;
using SportskiCentarRS2.Application.Prostorije.Queries.GetAllProstorije;
using SportskiCentarRS2.Application.Prostorije.Queries.GetProstorijuById;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.WebApi.Controllers
{
    [Authorize]
    public class ProstorijeController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ProstorijaDto>>> GetAll(CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetAllProstorijeQuery(), cancellationToken);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProstorijaVM>> GetById([FromRoute] int id, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetProstorijuByIdQuery { Id = id }, cancellationToken);
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateProstorijuCommand command, CancellationToken cancellationToken)
        {
            return await Mediator.Send(command, cancellationToken);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateProstorijuCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
                return BadRequest();

            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteProstorijuCommand { Id = id }, cancellationToken);
            return NoContent();
        }
    }
}
