using AutoMapper;
using Teddy.Dto;
using Teddy.Models;

namespace Teddy.Helper;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {

        //reverse, para fazer o post
        // recebido, saida
        CreateMap<Pokemon, PokemonDto>();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Country, CountryDto>().ReverseMap();
        CreateMap<Owner, OwnerDto>();
        CreateMap<Review, ReviewDto>();
    }
}
