using Reviewer.Services.Models;
using Reviewer.Services.Models.Api;

namespace Reviewer.Services.Abstractions.Api
{
    public interface IMoviesService
    {
        Task<List<MovieDetails>> GetMovies(RequestFilters filters);
    }
}
