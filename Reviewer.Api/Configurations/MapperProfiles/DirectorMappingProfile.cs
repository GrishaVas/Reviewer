using AutoMapper;
using Reviewer.Infrastructure.Models;
using Reviewer.Services.Models.Admin;
using Reviewer.Services.Models.Api;

namespace Reviewer.Api.Configurations.MapperProfiles
{
    public class DirectorMappingProfile : Profile
    {
        public DirectorMappingProfile()
        {
            CreateMap<Director, DirectorResponse>();
            CreateMap<CreateDirectorRequest, Director>()
                .ForMember(d => d.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.SecondName}"));
            CreateMap<UpdateDirectorRequest, Director>()
                .ForMember(d => d.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.SecodName}"));

            CreateMap<Director, DirectorDetails>();
        }
    }
}
