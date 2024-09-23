using AutoMapper;
using Reviewer.Infrastructure.Abstractions;
using Reviewer.Infrastructure.Models;
using Reviewer.Services.Abstractions.Admin;
using Reviewer.Services.Models;
using Reviewer.Services.Models.Admin;

namespace Reviewer.Services.Implemintations.Admin
{
    public class AdminMoviesService : BaseAdminService<CreateMovieRequest, UpdateMovieRequest, Movie, MovieResponse>, IAdminMoviesService
    {
        public AdminMoviesService(IMoviesRepository repository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
        {
        }

        public Task<ListData<MovieResponse>> GetList(RequestFilters filters)
        {
            return base.GetList(filters, m => filters.Search == null || m.Name.ToLower().Contains(filters.Search.ToLower()));
        }

        public override Task<MovieResponse> Create(CreateMovieRequest create)
        {
            create.ReleaseDate = create.ReleaseDate.ToUniversalTime();

            return base.Create(create);
        }
    }
}
