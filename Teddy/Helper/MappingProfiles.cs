using AutoMapper;
using Teddy.Dto;
using Teddy.Models;

namespace Teddy.Helper;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<Pokemon, PokemonDto>();
    }
}
