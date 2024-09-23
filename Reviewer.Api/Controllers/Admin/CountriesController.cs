using Microsoft.AspNetCore.Mvc;
using Reviewer.Infrastructure.Models;
using Reviewer.Services.Abstractions.Admin;
using Reviewer.Services.Models;
using Reviewer.Services.Models.Admin;

namespace Reviewer.Api.Controllers.Admin
{
    public class CountriesController : BaseAdminController<CreateCountryRequest, UpdateCountryRequest, Country, CountryResponse, IAdminCountriesService>
    {
        public CountriesController(IAdminCountriesService service) : base(service)
        {
        }

        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CountryResponse))]
        public override Task<IActionResult> Create(CreateCountryRequest create)
        {
            return base.Create(create);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CountryResponse))]
        public override Task<IActionResult> Get(Guid id)
        {
            return base.Get(id);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{name}/id")]
        public IActionResult GetIdByName(string name)
        {
            return Ok(Guid.Empty);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListData<CountryResponse>))]
        public override Task<IActionResult> GetList([FromQuery] RequestFilters filters)
        {
            return base.GetList(filters);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CountryResponse))]
        public override Task<IActionResult> Update(UpdateCountryRequest update)
        {
            return base.Update(update);
        }
    }
}
