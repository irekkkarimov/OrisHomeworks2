using TeamHost.Application.DTOs.StaticFile;
using TeamHost.Domain.Entities.ChatEntities;

namespace TeamHost.Application.DTOs.Chats;

public class GetChatDto
{
    public string Title { get; set; } = null!;
    public GetStaticFileDto? Image { get; set; }
    public string? LastMessage { get; set; }
}