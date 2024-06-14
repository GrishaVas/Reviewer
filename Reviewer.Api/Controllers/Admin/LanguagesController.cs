using Microsoft.AspNetCore.Mvc;
using Reviewer.Infrastructure.Models;
using Reviewer.Services.Abstractions.Admin;
using Reviewer.Services.Models;
using Reviewer.Services.Models.Admin;

namespace Reviewer.Api.Controllers.Admin
{
    public class LanguagesController : BaseAdminController<CreateLanguageRequest, UpdateLanguageRequest, Language, LanguageResponse, IAdminLanguagesService>
    {
        public LanguagesController(IAdminLanguagesService service) : base(service)
        {
        }

        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(LanguageResponse))]
        public override Task<IActionResult> Create(CreateLanguageRequest create)
        {
            return base.Create(create);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LanguageResponse))]
        public override Task<IActionResult> Get(Guid id)
        {
            return base.Get(id);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<LanguageResponse>))]
        public override Task<IActionResult> GetList([FromQuery] RequestFilters filters)
        {
            return base.GetList(filters);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LanguageResponse))]
        public override Task<IActionResult> Update(UpdateLanguageRequest update)
        {
            return base.Update(update);
        }
    }
}
