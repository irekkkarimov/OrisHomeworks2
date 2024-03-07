using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PokemonAPI.Models;
using PokemonAPI.Services.PokeApiService;

namespace PokemonAPI.Controllers;

[Route("[controller]/[action]")]
public class PokemonController : ControllerBase
{
    private readonly IPokeApiService _pokeApiService;

    public PokemonController(IPokeApiService pokeApiService)
    {
        _pokeApiService = pokeApiService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int limit, int offset)
    {
        return Ok(await _pokeApiService.GetByFilterAsync("", limit, offset));
    }
    
    [HttpGet]
    [Route("{filter}")]
    public async Task<IActionResult> GetByFilter(string filter)
    {
        var pokemonDataDtoList = await _pokeApiService.GetByFilterAsync(filter);
        return Ok(pokemonDataDtoList);
    }

    [HttpGet]
    [Route("{idOrName}")]
    public async Task<IActionResult> GetByIdOrName(string idOrName)
    {
        var pokemonDataDto = await _pokeApiService.GetByIdOrNameAsync(idOrName);

        if (pokemonDataDto is null)
            return NotFound();
            
        return Ok(pokemonDataDto);
    }
}