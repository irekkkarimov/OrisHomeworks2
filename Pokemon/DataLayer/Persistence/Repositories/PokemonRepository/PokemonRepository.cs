using Domain.Entities;

namespace DataLayer.Persistence.Repositores.PokemonRepository;

public class PokemonRepository : IPokemonRepository
{
    public Task Add(Pokemon pokemon)
    {
        throw new NotImplementedException();
    }

    public Task Remove(Pokemon pokemon)
    {
        throw new NotImplementedException();
    }

    public Task Update(Pokemon pokemon)
    {
        throw new NotImplementedException();
    }

    public Task<List<Pokemon>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Pokemon> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Pokemon> GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<Pokemon> FilterByName(string filter)
    {
        throw new NotImplementedException();
    }
}