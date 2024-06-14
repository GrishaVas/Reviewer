using Microsoft.AspNetCore.Mvc;
using Reviewer.Infrastructure.Models;
using Reviewer.Services.Abstractions.Admin;
using Reviewer.Services.Models;
using Reviewer.Services.Models.Admin;

namespace Reviewer.Api.Controllers.Admin
{
    public class RolesController : BaseAdminController<CreateRoleRequest, UpdateRoleRequest, Role, RoleResponse, IAdminRolesService>
    {
        public RolesController(IAdminRolesService service) : base(service)
        {
        }

        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RoleResponse))]
        public override Task<IActionResult> Create(CreateRoleRequest create)
        {
            return base.Create(create);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RoleResponse))]
        public override Task<IActionResult> Get(Guid id)
        {
            return base.Get(id);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RoleResponse>))]
        public override Task<IActionResult> GetList([FromQuery] RequestFilters filters)
        {
            return base.GetList(filters);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RoleResponse))]
        public override Task<IActionResult> Update(UpdateRoleRequest update)
        {
            return base.Update(update);
        }
    }
}
