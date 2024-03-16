using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Services.PokemonService;

namespace PokemonAPI.Controllers;

[Route("[controller]/[action]")]
public class PokemonController : ControllerBase
{
    private readonly IPokemonService _pokemonService;

    public PokemonController(IPokemonService service)
    {
        _pokemonService = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int limit, int offset)
    {
        var responseDto = await _pokemonService.GetAllAsync(limit, offset);
        return Ok(responseDto);
    }

    [HttpGet]
    [Route("{filter}")]
    public async Task<IActionResult> GetByFilter(int limit, int offset, string filter)
    {
        var responseDto = await _pokemonService.GetByFilterAsync(filter, limit, offset);
        return Ok(responseDto);
    }

    [HttpGet]
    [Route("{idOrName}")]
    public async Task<IActionResult> GetByIdOrName(string idOrName)
    {
        var pokemonDataDto = await _pokemonService.GetByIdOrNameAsync(idOrName);

        if (pokemonDataDto is null)
            return NotFound();
 
        return Ok(pokemonDataDto);
    }
}