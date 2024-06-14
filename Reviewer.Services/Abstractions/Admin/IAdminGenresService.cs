using Reviewer.Infrastructure.Models;
using Reviewer.Services.Models.Admin;

namespace Reviewer.Services.Abstractions.Admin
{
    public interface IAdminGenresService : IBaseAdminService<CreateGenreRequest, UpdateGenreRequest, Genre, GenreResponse>
    {
    }
}
