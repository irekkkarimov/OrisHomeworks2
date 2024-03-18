using Domain.Entities;
using Type = Domain.Entities.Type;

namespace DataLayer.Services;

public interface IPokeApiFetcher
{
    List<Pokemon> FetchAllPokemons();
    List<Type> FetchAllTypes();
    List<Move> FetchAllMoves();
    List<Ability> FetchAllAbilities();
}