using Microsoft.AspNetCore.Mvc;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Application.Uplate.Commands;
using SportskiCentarRS2.Application.Uplate.Queries.GetAllUplate;
using SportskiCentarRS2.WebApi.Hubs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.WebApi.Controllers
{
    public class UplateController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<UplataDto>>> GetAll([FromQuery] GetAllUplateQuery request, CancellationToken cancellationToken)
        {
            return await Mediator.Send(request, cancellationToken);
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateUplatuCommand command, CancellationToken cancellationToken)
        {
            return await Mediator.Send(command, cancellationToken);
        }
    }
}
