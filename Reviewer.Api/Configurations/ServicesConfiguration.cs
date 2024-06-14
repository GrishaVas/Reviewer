using Reviewer.Services.Abstractions.Admin;
using Reviewer.Services.Abstractions.Api;
using Reviewer.Services.Implemintations.Admin;
using Reviewer.Services.Implemintations.Api;

namespace Reviewer.Api.Configurations
{
    public static class ServicesConfiguration
    {
        public static void AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IAdminMoviesService, AdminMoviesService>();
            services.AddScoped<IAdminCountriesService, AdminCountriesService>();
            services.AddScoped<IAdminDirectorsService, AdminDirectorsService>();
            services.AddScoped<IAdminActorsService, AdminActorsService>();
            services.AddScoped<IAdminLanguagesService, AdminLanguagesService>();
            services.AddScoped<IAdminGenresService, AdminGenresService>();
            services.AddScoped<IAdminRolesService, AdminRolesService>();
            services.AddScoped<IMoviesService, MoviesService>();
        }
    }
}
