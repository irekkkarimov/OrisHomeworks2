using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamHost.Application.DTOs.Chats;
using TeamHost.Application.DTOs.StaticFile;
using TeamHost.Application.Interfaces.Repositories;
using TeamHost.Domain.Entities.ChatEntities;

namespace TeamHost.Application.Features.Chats.Queries;

/// <summary>
/// Запрос на получение всех чатов пользователя
/// </summary>
public class GetAllChatsQuery : IRequest<List<GetChatDto>>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userId">Id пользователя</param>
    public GetAllChatsQuery(Guid userId)
    {
        UserId = userId;
    }

    /// <summary>
    /// Id пользователя
    /// </summary>
    public Guid UserId { get; set; }
}

/// <summary>
/// Обработчик запроса на получение всех чатов пользователя
/// </summary>
internal class GetAllChatsQueryHandler : IRequestHandler<GetAllChatsQuery, List<GetChatDto>>
{
    private readonly IGenericRepository<Chat> _chatRepository;
    private readonly IMapper _mapper;


    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="chatRepository">Репозиторий чатов</param>
    /// <param name="mapper">Маппер объектов</param>
    public GetAllChatsQueryHandler(IGenericRepository<Chat> chatRepository, IMapper mapper)
    {
        _chatRepository = chatRepository;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<List<GetChatDto>> Handle(GetAllChatsQuery request, CancellationToken cancellationToken)
    {
        return await _chatRepository
            .Entities
            .Include(i => i.UserInfos)
            .Where(i => i.UserInfos.Any(e => e.UserId == request.UserId))
            .Select(i => new GetChatDto
            {
                Title = i.Title,
                Image = i.Image != null ? new GetStaticFileDto
                {
                    Path = i.Image.Path,
                    Size = i.Image.Size,
                    Name = i.Image.Name,
                    Extension = i.Image.Extension,
                    IsMainImage = i.Image.IsMainImage
                } : null,
                LastMessage = i.Messages.Any() ? i.Messages[0].MessageContent : null
            })
            .ToListAsync(cancellationToken: cancellationToken);
    }
}