using Reviewer.Infrastructure.Abstractions;
using Reviewer.Infrastructure.Models;

namespace Reviewer.Infrastructure.Implemintations
{
    public class RolesRepository : BaseRepository<Role>, IRolesRepository
    {
        public RolesRepository(ReviewerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
