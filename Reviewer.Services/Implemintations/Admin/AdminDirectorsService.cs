using AutoMapper;
using Reviewer.Infrastructure.Abstractions;
using Reviewer.Infrastructure.Models;
using Reviewer.Services.Abstractions.Admin;
using Reviewer.Services.Models;
using Reviewer.Services.Models.Admin;

namespace Reviewer.Services.Implemintations.Admin
{
    public class AdminDirectorsService : BaseAdminService<CreateDirectorRequest, UpdateDirectorRequest, Director, DirectorResponse>, IAdminDirectorsService
    {
        public AdminDirectorsService(IDirectorsRepository repository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
        {
        }

        public Task<List<DirectorResponse>> GetList(RequestFilters filters)
        {
            return base.GetList(filters, d => filters.Search == null || d.Name.ToLower().Contains(filters.Search.ToLower()));
        }
    }
}
