using AutoMapper;
using Reviewer.Infrastructure.Abstractions;
using Reviewer.Infrastructure.Models;
using Reviewer.Services.Abstractions.Admin;
using Reviewer.Services.Models;
using Reviewer.Services.Models.Admin;

namespace Reviewer.Services.Implemintations.Admin
{
    public class AdminCountriesService : BaseAdminService<CreateCountryRequest, UpdateCountryRequest, Country, CountryResponse>, IAdminCountriesService
    {
        public AdminCountriesService(ICountriesRepository repository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
        {
        }

        public Task<ListData<CountryResponse>> GetList(RequestFilters filters)
        {
            return base.GetList(filters, c => string.IsNullOrEmpty(filters.Search) || c.Name.ToLower().Contains(filters.Search.ToLower()));
        }
    }
}
