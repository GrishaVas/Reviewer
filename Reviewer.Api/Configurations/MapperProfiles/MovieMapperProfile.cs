using AutoMapper;
using Reviewer.Infrastructure.Models;
using Reviewer.Services.Models.Admin;
using Reviewer.Services.Models.Api;

namespace Reviewer.Api.Configurations.MapperProfiles
{
    public class MovieMapperProfile : Profile
    {
        public MovieMapperProfile()
        {
            CreateMap<Movie, MovieResponse>();
            CreateMap<CreateMovieRequest, Movie>()
                .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => src.Countries.Select(c => new MovieCountry
                {
                    CountryId = c
                })))
                .ForMember(dest => dest.Directors, opt => opt.MapFrom(src => src.Directors.Select(d => new MovieDirector
                {
                    DirectorId = d
                })))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(g => new MovieGenre
                {
                    GenreId = g
                })))
                .ForMember(dest => dest.Languages, opt => opt.MapFrom(src => src.Languages.Select(l => new MovieLanguage
                {
                    LanguageId = l
                })));
            CreateMap<Movie, Guid>()
                .ForSourceMember(m => m.Id, opt => opt.DoNotValidate());
            CreateMap<MovieCountry, Guid>()
                .ForSourceMember(mc => mc.CountryId, opt => opt.DoNotValidate());
            CreateMap<MovieGenre, Guid>()
                .ForSourceMember(mg => mg.GenreId, opt => opt.DoNotValidate());
            CreateMap<MovieDirector, Guid>()
                .ForSourceMember(md => md.DirectorId, opt => opt.DoNotValidate());
            CreateMap<MovieLanguage, Guid>()
                .ForSourceMember(ml => ml.LanguageId, opt => opt.DoNotValidate());

            CreateMap<Movie, MovieDetails>();
            CreateMap<MovieCountry, CountryDetails>()
                .ForSourceMember(mc => mc.Country, opt => opt.DoNotValidate());
            CreateMap<MovieGenre, GenreDetails>()
                .ForSourceMember(mc => mc.Genre, opt => opt.DoNotValidate());
            CreateMap<MovieDirector, DirectorDetails>()
                .ForSourceMember(mc => mc.Director, opt => opt.DoNotValidate());
            CreateMap<MovieLanguage, LanguageDetails>()
                .ForSourceMember(mc => mc.Language, opt => opt.DoNotValidate());
        }
    }
}
