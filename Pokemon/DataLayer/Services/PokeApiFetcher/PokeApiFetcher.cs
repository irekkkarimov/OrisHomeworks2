using System.Collections.Immutable;
using DataLayer.FetchDTO;
using DataLayer.FetchDTO.Ability;
using DataLayer.FetchDTO.Move;
using DataLayer.FetchDTO.Types;
using Domain.Entities;
using Newtonsoft.Json;
using Ability = Domain.Entities.Ability;
using Move = Domain.Entities.Move;
using Type = Domain.Entities.Type;

namespace DataLayer.Services;

public class PokeApiFetcher : IPokeApiFetcher
{
    private const string Url = "https://pokeapi.co/api/v2/";
    private readonly HttpClient _httpClient = new();

    public List<Pokemon> FetchAllPokemons()
    {
        const string specificUrl = Url + "pokemon" + "?limit=10000";
        var responseResult = _httpClient.GetStringAsync(specificUrl).Result;
        var pokemonsReceived = JsonConvert.DeserializeObject<PokeApiRequestDto>(responseResult);

        if (pokemonsReceived is null)
            throw new NullReferenceException("Pokemons not found");

        var pokemons = pokemonsReceived.Results;
        var pokemonsDetailed = new List<Pokemon>();

        foreach (var newPokemon in pokemons
                     .Select(pokemon => JsonConvert.DeserializeObject<Pokemon>(_httpClient
                         .GetStringAsync(pokemon.Url)
                         .Result)))
        {
            if (newPokemon is null) throw new NullReferenceException("Pokemon not found");
            pokemonsDetailed.Add(newPokemon);
        }

        return pokemonsDetailed;
    }

    public List<Type> FetchAllTypes()
    {
        const string specificUrl = Url + "type" + "?limit=100";
        var responseResult = _httpClient.GetStringAsync(specificUrl).Result;
        var typesReceived = JsonConvert.DeserializeObject<TypesFetchDto>(responseResult);

        if (typesReceived is null)
            throw new NullReferenceException("Pokemons not found");

        var typeDtoList = typesReceived.Results;

        var typeList = typeDtoList
            .Select(typeDto =>
                new Type
                {
                    Id = int.Parse(typeDto.Url.Split('/')[^2]),
                    Name = typeDto.Name, 
                    Pokemons = new List<Pokemon>()
                })
            .ToList();

        return typeList;
    }

    public List<Move> FetchAllMoves()
    {
        const string specificUrl = Url + "move" + "?limit=10000";
        var responseResult = _httpClient.GetStringAsync(specificUrl).Result;
        var movesReceived = JsonConvert.DeserializeObject<MovesFetchDto>(responseResult);

        if (movesReceived is null || !movesReceived.Results.Any())
            throw new NullReferenceException("Moves not found");

        var moveDtoList = movesReceived.Results;

        var moveList = moveDtoList
            .Select(moveDto =>
                new Move
                {
                    Id = int.Parse(moveDto.Url.Split('/')[^2]),
                    Name = moveDto.Name,
                    Pokemons = new()
                })
            .ToList();

        return moveList;
    }

    public List<Ability> FetchAllAbilities()
    {
        const string specificUrl = Url + "ability" + "?limit=10000";
        var responseResult = _httpClient.GetStringAsync(specificUrl).Result;
        var abilitiesReceived = JsonConvert.DeserializeObject<AbilitiesFetchDto>(responseResult);

        if (abilitiesReceived is null || !abilitiesReceived.Results.Any())
            throw new NullReferenceException("Abilities not found");

        var abilityDtoList = abilitiesReceived.Results;

        var abilityList = abilityDtoList
            .Select(abilityDto =>
                new Ability
                {
                    Id = int.Parse(abilityDto.Url.Split('/')[^2]),
                    Name = abilityDto.Name,
                    Pokemons = new List<Pokemon>()
                })
            .ToList();

        return abilityList;
    }
}