using Microsoft.AspNetCore.Mvc;
using Reviewer.Infrastructure.Models;
using Reviewer.Services.Abstractions.Admin;
using Reviewer.Services.Models;
using Reviewer.Services.Models.Admin;

namespace Reviewer.Api.Controllers.Admin
{
    public class GenresController : BaseAdminController<CreateGenreRequest, UpdateGenreRequest, Genre, GenreResponse, IAdminGenresService>
    {
        public GenresController(IAdminGenresService service) : base(service)
        {
        }

        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CountryResponse))]
        public override Task<IActionResult> Create(CreateGenreRequest create)
        {
            return base.Create(create);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CountryResponse))]
        public override Task<IActionResult> Get(Guid id)
        {
            return base.Get(id);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CountryResponse>))]
        public override Task<IActionResult> GetList([FromQuery] RequestFilters filters)
        {
            return base.GetList(filters);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CountryResponse))]
        public override Task<IActionResult> Update(UpdateGenreRequest update)
        {
            return base.Update(update);
        }
    }
}
