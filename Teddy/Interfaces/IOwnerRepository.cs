using Teddy.Models;

namespace Teddy.Interfaces;

public interface IOwnerRepository
{
    ICollection<Owner> GetOwners();
    Owner GetOwner(long id);
    ICollection<Owner> GetOwnerOfAPokemon(long pokeId);
    ICollection<Pokemon> GetPokemonByOwner(long ownerId);
    bool OwnerExists(long id);

    bool CreateOwner(Owner owner);
}