using AutoMapper;
using Reviewer.Infrastructure.Models;
using Reviewer.Services.Models.Admin;
using Reviewer.Services.Models.Api;

namespace Reviewer.Api.Configurations.MapperProfiles
{
    public class CountryMappingProfile : Profile
    {
        public CountryMappingProfile()
        {
            CreateMap<CreateCountryRequest, Country>();
            CreateMap<Country, CountryResponse>();

            CreateMap<Country, CountryDetails>();
        }
    }
}
