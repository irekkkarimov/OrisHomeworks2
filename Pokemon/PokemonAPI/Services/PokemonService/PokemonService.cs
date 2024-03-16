using PokemonAPI.DTO.Pokemon;
using PokemonAPI.Models;
using PokemonAPI.Models.DTOs.ResponseDTOs;

namespace PokemonAPI.Services.PokemonService;

public class PokemonService : IPokemonService
{
    public Task<PokemonLessListGetDto> GetAllAsync(int limit, int offset)
    {
        throw new NotImplementedException();
    }

    public Task<PokemonLessListGetDto> GetByFilterAsync(string filter, int limit, int offset)
    {
        throw new NotImplementedException();
    }

    public Task<PokemonGetDto?> GetByIdOrNameAsync(string idOrName)
    {
        throw new NotImplementedException();
    }
}