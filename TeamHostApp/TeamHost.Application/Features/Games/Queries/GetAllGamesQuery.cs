using AutoMapper;
using MediatR;
using TeamHost.Application.DTOs.Game;
using TeamHost.Application.Interfaces.Repositories;
using TeamHost.Domain.Entities.GameEntities;

namespace TeamHost.Application.Features.Games.Queries;

public class GetAllGamesQuery : IRequest<List<GetGameDto>>
{
    
}

internal class GetAllGamesQueryHandler : IRequestHandler<GetAllGamesQuery, List<GetGameDto>>
{
    private readonly IGameRepository _gameRepository;
    private readonly IMapper _mapper;

    public GetAllGamesQueryHandler(IGameRepository gameRepository, IMapper mapper)
    {
        _gameRepository = gameRepository;
        _mapper = mapper;
    }

    public async Task<List<GetGameDto>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
    {
        var allGames = await _gameRepository.GetAllAsync();
        
        var allGamesMapped = allGames
            .Select(i => _mapper.Map<GetGameDto>(i))
            .ToList();

        Console.WriteLine(allGamesMapped[0].MainImage);
        
        return allGamesMapped;
    }
}