using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Application.HelperModels;
using SportskiCentarRS2.Application.Notifikacije.Commands.CreateNotifikaciju;
using SportskiCentarRS2.Application.Rezervacije.Commands.CreateRezervaciju;
using SportskiCentarRS2.Application.Rezervacije.Commands.DeleteRezervaciju;
using SportskiCentarRS2.Application.Rezervacije.Commands.UpdateRezervaciju;
using SportskiCentarRS2.Application.Rezervacije.Queries.GetRezervacijeWithPagination;
using SportskiCentarRS2.Application.Rezervacije.Queries.GetRezervacijuById;
using SportskiCentarRS2.WebApi.Hubs;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.WebApi.Controllers
{
    [Authorize]
    public class RezervacijeController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<RezervacijaDto>>> GetWithPagination([FromQuery] GetRezervacijeWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await Mediator.Send(request, cancellationToken);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RezervacijaVM>> GetById([FromRoute] int id, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetRezervacjiuByIdQuery { Id = id }, cancellationToken);
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateRezervacijuCommand command, CancellationToken cancellationToken)
        {
            return await Mediator.Send(command, cancellationToken);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateRezervacijuCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
                return BadRequest();
            if(command.Odobrena != null && command.Odobrena == true)
            {
                var rezervacijaVm = await Mediator.Send(new GetRezervacjiuByIdQuery { Id = id }, cancellationToken);
                var poruka = $"Odobrena rezervacija za prostoriju {rezervacijaVm.Prostorija} u terminu {rezervacijaVm.Termin}";
                await _notifikacijeHub.Clients.All.SendAsync("ReceiveMessage", rezervacijaVm.Klijent, poruka, cancellationToken);
                await Mediator.Send(new CreateNotifikacijuCommand { PrimalacUsername = rezervacijaVm.Klijent, Poruka = poruka }, cancellationToken);
            }
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteRezervacijuCommand { Id = id }, cancellationToken);
            return NoContent();
        }
    }
}
