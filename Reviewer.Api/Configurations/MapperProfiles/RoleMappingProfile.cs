using AutoMapper;
using Reviewer.Infrastructure.Models;
using Reviewer.Services.Models.Admin;
using Reviewer.Services.Models.Api;

namespace Reviewer.Api.Configurations.MapperProfiles
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<CreateRoleRequest, Role>()
                .ForMember(r => r.ActorId, opt => opt.MapFrom(src => src.Actor))
                .ForMember(r => r.Actor, opt => opt.Ignore());
            CreateMap<UpdateRoleRequest, Role>();
            CreateMap<Role, RoleResponse>();
            CreateMap<Role, Guid>()
                .ForSourceMember(r => r.Id, opt => opt.DoNotValidate());

            CreateMap<Role, RoleDetails>();
        }
    }
}
