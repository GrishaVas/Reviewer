using AutoMapper;
using Reviewer.Infrastructure.Abstractions;
using Reviewer.Infrastructure.Models;
using Reviewer.Services.Abstractions.Admin;
using Reviewer.Services.Models;
using Reviewer.Services.Models.Admin;

namespace Reviewer.Services.Implemintations.Admin
{
    public class AdminActorsService : BaseAdminService<CreateActorRequest, UpdateActorRequest, Actor, ActorResponse>, IAdminActorsService
    {
        public AdminActorsService(IActorsRepository repository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
        {
        }

        public Task<List<ActorResponse>> GetList(RequestFilters filters)
        {
            return base.GetList(filters, a => filters.Search == null || a.Name.ToLower().Contains(filters.Search.ToLower()));
        }
    }
}
