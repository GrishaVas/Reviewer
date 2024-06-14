using AutoMapper;
using Reviewer.Infrastructure.Abstractions;
using Reviewer.Infrastructure.Models;
using Reviewer.Services.Abstractions.Admin;
using Reviewer.Services.Models;
using Reviewer.Services.Models.Admin;

namespace Reviewer.Services.Implemintations.Admin
{
    public class AdminRolesService : BaseAdminService<CreateRoleRequest, UpdateRoleRequest, Role, RoleResponse>, IAdminRolesService
    {
        public AdminRolesService(IRolesRepository repository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
        {
        }

        public Task<List<RoleResponse>> GetList(RequestFilters filters)
        {
            return base.GetList(filters, r => filters.Search == null || r.Name.ToLower().Contains(filters.Search.ToLower()));
        }
    }
}
