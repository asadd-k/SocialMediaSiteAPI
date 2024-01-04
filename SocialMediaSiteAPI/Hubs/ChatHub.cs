using Microsoft.AspNetCore.SignalR;

namespace SocialMediaSiteAPI.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user1, string user2, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user1, user2, message);
        }
    }
}
