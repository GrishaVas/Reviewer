using Microsoft.AspNetCore.Mvc;
using Reviewer.Infrastructure.Models;
using Reviewer.Services.Abstractions.Admin;
using Reviewer.Services.Models;
using Reviewer.Services.Models.Admin;

namespace Reviewer.Api.Controllers.Admin
{
    public class DirectorsController : BaseAdminController<CreateDirectorRequest, UpdateDirectorRequest, Director, DirectorResponse, IAdminDirectorsService>
    {
        public DirectorsController(IAdminDirectorsService service) : base(service)
        {
        }

        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DirectorResponse))]
        public override Task<IActionResult> Create(CreateDirectorRequest create)
        {
            return base.Create(create);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DirectorResponse))]
        public override Task<IActionResult> Get(Guid id)
        {
            return base.Get(id);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DirectorResponse>))]
        public override Task<IActionResult> GetList([FromQuery] RequestFilters filters)
        {
            return base.GetList(filters);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DirectorResponse))]
        public override Task<IActionResult> Update(UpdateDirectorRequest update)
        {
            return base.Update(update);
        }
    }
}
