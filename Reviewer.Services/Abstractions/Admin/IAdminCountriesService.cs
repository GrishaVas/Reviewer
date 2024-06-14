using Reviewer.Infrastructure.Models;
using Reviewer.Services.Models.Admin;

namespace Reviewer.Services.Abstractions.Admin
{
    public interface IAdminCountriesService : IBaseAdminService<CreateCountryRequest, UpdateCountryRequest, Country, CountryResponse>
    {
    }
}
