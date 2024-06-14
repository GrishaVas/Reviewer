using Reviewer.Infrastructure.Abstractions;
using Reviewer.Infrastructure.Models;

namespace Reviewer.Infrastructure.Implemintations
{
    public class DirectorsRepository : BaseRepository<Director>, IDirectorsRepository
    {
        public DirectorsRepository(ReviewerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
