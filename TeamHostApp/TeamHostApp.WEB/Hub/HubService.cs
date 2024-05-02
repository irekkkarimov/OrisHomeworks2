using Microsoft.AspNetCore.SignalR;
using TeamHost.Application.Interfaces;
using TeamHost.Application.Models;

namespace TeamHostApp.WEB.Hub;

public class HubService : IHubService
{
    private readonly IHubContext<ChatHub> _hubContext;

    public HubService(IHubContext<ChatHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendMessageAsync(Message message)
    {
        if (!message.ReceiverIds.Any())
            return;

        await _hubContext.Clients.Users(
                message.ReceiverIds
                    .Select(i => i.ToString())
                    .ToList())
            .SendAsync("ReceiveMessage", new
            {
                message.Content,
                message.SenderId,
                Images = message.Images
                    .Select(e => new
                    {
                        UserId = e.Key,
                        Image = e.Value
                    })
                    .ToList(),
                message.SenderName
            });
    }
}