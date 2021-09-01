using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportskiCentarRS2.Application.Opreme.Commands.CreateOpremu;
using SportskiCentarRS2.Application.Opreme.Commands.DeleteOpremu;
using SportskiCentarRS2.Application.Opreme.Commands.UpdateOpremu;
using SportskiCentarRS2.Application.Opreme.Queries.GetAllOpremu;
using SportskiCentarRS2.Application.Opreme.Queries.GetOpremuById;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.WebApi.Controllers
{
    [Authorize]
    public class OpremaController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OpremaDto>>> GetAll(CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetAllOpremuQuery(), cancellationToken);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OpremaVM>> GetById([FromRoute] int id, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetOpremuByIdQuery { Id = id }, cancellationToken);
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateOpremuCommand command, CancellationToken cancellationToken)
        {
            return await Mediator.Send(command, cancellationToken);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateOpremuCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
                return BadRequest();

            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteOpremuCommand { Id = id }, cancellationToken);
            return NoContent();
        }
    }
}
