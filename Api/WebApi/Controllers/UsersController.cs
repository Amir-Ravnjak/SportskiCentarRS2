using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportskiCentarRS2.Application.HelperModels;
using SportskiCentarRS2.Application.Korisnici.Commands.CreateKorisnik;
using SportskiCentarRS2.Application.Korisnici.Commands.DeleteKorisnik;
using SportskiCentarRS2.Application.Korisnici.Commands.UpdateKorisnik;
using SportskiCentarRS2.Application.Korisnici.Queries.GetAllKorisnici;
using SportskiCentarRS2.Application.Korisnici.Queries.GetKorisniciWithPagination;
using SportskiCentarRS2.Application.Korisnici.Queries.GetUserById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : ApiControllerBase
    {
        
        [HttpGet]
        public async Task<ActionResult<PaginatedList<KorisnikDto>>> GetUsers([FromQuery] GetKorisniciWithPaginationQuery korisniciQuery, CancellationToken token)
        {
            return await Mediator.Send(korisniciQuery, token);
        }
        [HttpGet("all")]
        public async Task<ActionResult<List<KorisnikDto>>> GetAllUsers([FromQuery] GetAllKorisniciQuery korisniciQuery, CancellationToken token)
        {
            return await Mediator.Send(korisniciQuery, token);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<KorisnikVM>> GetUserById([FromRoute] int id, CancellationToken token)
        {
            return await Mediator.Send(new GetKorisnikByIdQuery { Id = id }, token);
        }
        [HttpPost]
        public async Task<ActionResult<int>> CreateUser([FromBody]CreateKorisnikCommand command, CancellationToken token)
        {
            return await Mediator.Send(command, token);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateKorisnikCommand korisnik, [FromRoute] int id, CancellationToken token)
        {
            if (korisnik.Id != id)
                return BadRequest();

            await Mediator.Send(korisnik, token);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<KorisnikDto>> DeleteUser([FromRoute] int id, CancellationToken token)
        {
            await Mediator.Send(new DeleteKorisnikCommand { Id = id }, token);
            
            return NoContent();
        }
    }
}

