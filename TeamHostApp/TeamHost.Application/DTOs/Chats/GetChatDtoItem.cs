using TeamHost.Application.DTOs.StaticFile;

namespace TeamHost.Application.DTOs.Chats;

public class GetChatDtoItem
{
    public string Title { get; set; } = null!;
    public GetStaticFileDto? Image { get; set; }
    public string? LastMessage { get; set; }
}