using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Persistance.Configurations;

public class PokemonConfiguration : IEntityTypeConfiguration<Pokemon>
{
    public void Configure(EntityTypeBuilder<Pokemon> builder)
    {
        builder.HasKey(i => i.Id);

        builder
            .HasMany(i => i.Types)
            .WithMany(e => e.Pokemons);
        
        builder
            .HasMany(i => i.Moves)
            .WithMany(e => e.Pokemons);
        
        builder
            .HasMany(i => i.Abilities)
            .WithMany(e => e.Pokemons);
    }
}