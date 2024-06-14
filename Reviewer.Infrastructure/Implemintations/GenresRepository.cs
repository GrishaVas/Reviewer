using Reviewer.Infrastructure.Abstractions;
using Reviewer.Infrastructure.Models;

namespace Reviewer.Infrastructure.Implemintations
{
    public class GenresRepository : BaseRepository<Genre>, IGenresRepository
    {
        public GenresRepository(ReviewerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
