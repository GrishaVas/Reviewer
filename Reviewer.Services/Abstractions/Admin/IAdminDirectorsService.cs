using Reviewer.Infrastructure.Models;
using Reviewer.Services.Models.Admin;

namespace Reviewer.Services.Abstractions.Admin
{
    public interface IAdminDirectorsService : IBaseAdminService<CreateDirectorRequest, UpdateDirectorRequest, Director, DirectorResponse>
    {
    }
}
