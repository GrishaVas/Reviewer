using Reviewer.Infrastructure.Abstractions;
using Reviewer.Infrastructure.Models;

namespace Reviewer.Infrastructure.Implemintations
{
    public class MovieRepository : BaseRepository<Movie>, IMoviesRepository
    {
        public MovieRepository(ReviewerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
