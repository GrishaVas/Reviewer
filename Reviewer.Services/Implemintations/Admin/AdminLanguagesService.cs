using AutoMapper;
using Reviewer.Infrastructure.Abstractions;
using Reviewer.Infrastructure.Models;
using Reviewer.Services.Abstractions.Admin;
using Reviewer.Services.Models;
using Reviewer.Services.Models.Admin;

namespace Reviewer.Services.Implemintations.Admin
{
    public class AdminLanguagesService : BaseAdminService<CreateLanguageRequest, UpdateLanguageRequest, Language, LanguageResponse>, IAdminLanguagesService
    {
        public AdminLanguagesService(ILanguagesRepository repository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
        {
        }

        public Task<List<LanguageResponse>> GetList(RequestFilters filters)
        {
            return base.GetList(filters, l => filters.Search == null || l.Name.ToLower().Contains(filters.Search.ToLower()));
        }
    }
}
