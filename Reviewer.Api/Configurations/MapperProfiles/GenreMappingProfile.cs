using AutoMapper;
using Reviewer.Infrastructure.Models;
using Reviewer.Services.Models.Admin;
using Reviewer.Services.Models.Api;

namespace Reviewer.Api.Configurations.MapperProfiles
{
    public class GenreMappingProfile : Profile
    {
        public GenreMappingProfile()
        {
            CreateMap<CreateGenreRequest, Genre>();
            CreateMap<UpdateGenreRequest, Genre>();
            CreateMap<Genre, GenreResponse>();
            CreateMap<Genre, Guid>()
                .ForSourceMember(g => g.Id, opt => opt.DoNotValidate());

            CreateMap<Genre, GenreDetails>();
        }
    }
}
