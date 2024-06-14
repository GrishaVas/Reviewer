using AutoMapper;
using Reviewer.Infrastructure.Models;
using Reviewer.Services.Models.Admin;
using Reviewer.Services.Models.Api;

namespace Reviewer.Api.Configurations.MapperProfiles
{
    public class LanguageMappingProfile : Profile
    {
        public LanguageMappingProfile()
        {
            CreateMap<CreateLanguageRequest, Language>();
            CreateMap<UpdateLanguageRequest, Language>();
            CreateMap<Language, LanguageResponse>();

            CreateMap<Language, LanguageDetails>();
        }
    }
}
