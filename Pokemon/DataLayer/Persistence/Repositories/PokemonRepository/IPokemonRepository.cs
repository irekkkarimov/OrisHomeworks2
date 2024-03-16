using Domain.Entities;

namespace DataLayer.Persistence.Repositores.PokemonRepository;

public interface IPokemonRepository
{
    Task Add(Pokemon pokemon);
    Task Remove(Pokemon pokemon);
    Task Update(Pokemon pokemon);
    Task<List<Pokemon>> GetAll();
    Task<Pokemon> GetById(int id);
    Task<Pokemon> GetByName(string name);
    Task<Pokemon> FilterByName(string filter);
}