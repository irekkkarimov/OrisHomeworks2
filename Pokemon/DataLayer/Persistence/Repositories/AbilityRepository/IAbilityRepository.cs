using Domain.Entities;

namespace DataLayer.Persistence.Repositores.AbilityRepository;

public interface IAbilityRepository
{
    Task Add(Ability ability);
    Task Remove(Ability ability);
    Task Update(Ability ability);
    Task<List<Ability>> GetAll();
    Task<Ability> GetById(int id);
}