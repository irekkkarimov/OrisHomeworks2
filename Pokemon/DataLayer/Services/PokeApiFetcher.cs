using Domain.Entities;

namespace DataLayer.Services;

public class PokeApiFetcher : IPokeApiFetcher
{
    private readonly HttpClient _httpClient = new();

    public List<Pokemon> FetchAll()
    {
        
    }
}