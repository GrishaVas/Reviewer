using Reviewer.Infrastructure.Abstractions;
using Reviewer.Infrastructure.Implemintations;

namespace Reviewer.Api.Configurations
{
    public static class InfrastructureConfiguration
    {
        public static void AddInfrastructureConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IMoviesRepository, MovieRepository>();
            services.AddScoped<ICountriesRepository, CountriesRepository>();
            services.AddScoped<IDirectorsRepository, DirectorsRepository>();
            services.AddScoped<IActorsRepository, ActorsRepository>();
            services.AddScoped<ILanguagesRepository, LanguagesRepository>();
            services.AddScoped<IGenresRepository, GenresRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
