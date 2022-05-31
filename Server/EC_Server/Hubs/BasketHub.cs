using Microsoft.AspNetCore.SignalR;

namespace EC_Server.Hubs
{
    public class BasketHub : Hub
    {
        public async Task UpdateBasket(string clientId, object items)
        {
            await Clients.Client(clientId).SendAsync("UpdateBasket",items);
        }
    }
}