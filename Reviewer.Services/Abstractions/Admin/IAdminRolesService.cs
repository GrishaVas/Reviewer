using Reviewer.Infrastructure.Models;
using Reviewer.Services.Models.Admin;

namespace Reviewer.Services.Abstractions.Admin
{
    public interface IAdminRolesService : IBaseAdminService<CreateRoleRequest, UpdateRoleRequest, Role, RoleResponse>
    {
    }
}
