using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using SportskiCentarRS2.WebApi.Hubs;

namespace SportskiCentarRS2.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected IHubContext<NotifikacijeHub> _notifikacijeHub => HttpContext.RequestServices.GetService<IHubContext<NotifikacijeHub>>();
        private ISender _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
    }
}
