using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SportskiCentarRS2.WebApi.Hubs
{
    public class NotifikacijeHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
