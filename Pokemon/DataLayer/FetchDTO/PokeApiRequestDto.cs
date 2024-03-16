namespace DataLayer.FetchDtos;

public class PokeApiRequestDto
{
    public List<PokemonFetch> Results { get; init; } = new();
}