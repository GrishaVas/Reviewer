using AutoMapper;
using Reviewer.Infrastructure.Models;
using Reviewer.Services.Models.Admin;

namespace Reviewer.Api.Configurations.MapperProfiles
{
    public class ActorMappingProfile : Profile
    {
        public ActorMappingProfile()
        {
            CreateMap<CreateActorRequest, Actor>()
                .ForMember(a => a.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.SecondName}"));
            CreateMap<UpdateActorRequest, Actor>();
            CreateMap<Actor, ActorResponse>();

            //CreateMap<Actor, >();
        }
    }
}
