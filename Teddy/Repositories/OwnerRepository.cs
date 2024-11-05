using Teddy.Data;
using Teddy.Interfaces;
using Teddy.Models;

namespace Teddy.Repositories;

class OwnerRepository(DataContext db): IOwnerRepository
{
    private readonly DataContext _db = db;

    public ICollection<Owner> GetOwners()
    {
        return [.. _db.Owners];
    }

    public Owner GetOwner(long id)
    {
        return _db.Owners
            .Where(owner => owner.Id == id)
            .First();
        
    }

    public ICollection<Owner> GetOwnerOfAPokemon(long pokeId)
    {
        return [.. _db.PokemonOwners
            .Where(po => po.PokemonId == pokeId)
            .Select(o => o.Owner)];
    }


    public ICollection<Pokemon> GetPokemonByOwner(long ownerId)
    {
        return [.. _db.PokemonOwners
            .Where(po => po.OwnerId == ownerId)
            .Select(o => o.Pokemon)];
    }

    public bool OwnerExists(long id)
    {
        return _db.Owners.Any(o => o.Id == id);
    }

    public bool CreateOwner(Owner owner)
    {
        _db.Owners.Add(owner);

        return _db.SaveChanges() > 0;
    }
}