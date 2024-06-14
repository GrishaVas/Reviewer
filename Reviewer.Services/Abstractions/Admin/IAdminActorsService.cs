using Reviewer.Infrastructure.Models;
using Reviewer.Services.Models.Admin;

namespace Reviewer.Services.Abstractions.Admin
{
    public interface IAdminActorsService : IBaseAdminService<CreateActorRequest, UpdateActorRequest, Actor, ActorResponse>
    {
    }
}
