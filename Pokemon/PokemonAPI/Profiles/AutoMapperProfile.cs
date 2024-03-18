using AutoMapper;
using Domain.Entities;
using PokemonAPI.DTO.Ability;
using PokemonAPI.DTO.Move;
using PokemonAPI.DTO.Pokemon;
using PokemonAPI.DTO.Type;
using Type = Domain.Entities.Type;

namespace PokemonAPI.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Pokemon, PokemonGetDto>();
        CreateMap<Pokemon, PokemonLessGetDto>();

        CreateMap<Type, TypeGetDto>();

        CreateMap<Ability, AbilityGetDto>();

        CreateMap<Move, MoveGetDto>();
    }
}