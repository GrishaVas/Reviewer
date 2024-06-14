using AutoMapper;
using Reviewer.Infrastructure.Abstractions;
using Reviewer.Infrastructure.Models;
using Reviewer.Services.Abstractions.Admin;
using Reviewer.Services.Models;
using Reviewer.Services.Models.Admin;

namespace Reviewer.Services.Implemintations.Admin
{
    public class AdminGenresService : BaseAdminService<CreateGenreRequest, UpdateGenreRequest, Genre, GenreResponse>, IAdminGenresService
    {
        public AdminGenresService(IGenresRepository repository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
        {
        }

        public Task<List<GenreResponse>> GetList(RequestFilters filters)
        {
            return base.GetList(filters, g => filters.Search == null || g.Name.ToLower().Contains(filters.Search.ToLower()));
        }
    }
}
