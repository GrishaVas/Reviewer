using Reviewer.Infrastructure.Abstractions;
using Reviewer.Infrastructure.Models;

namespace Reviewer.Infrastructure.Implemintations
{
    public class ActorsRepository : BaseRepository<Actor>, IActorsRepository
    {
        public ActorsRepository(ReviewerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
