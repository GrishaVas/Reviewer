using Reviewer.Infrastructure.Models;
using Reviewer.Services.Models.Admin;

namespace Reviewer.Services.Abstractions.Admin
{
    public interface IAdminMoviesService : IBaseAdminService<CreateMovieRequest, UpdateMovieRequest, Movie, MovieResponse>
    {
    }
}
