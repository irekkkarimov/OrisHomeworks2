using Domain.Entities;

namespace DataLayer.Services;

public interface IPokeApiFetcher
{
    List<Pokemon> FetchAll();
}