using Reviewer.Infrastructure.Abstractions;
using Reviewer.Infrastructure.Models;

namespace Reviewer.Infrastructure.Implemintations
{
    public class LanguagesRepository : BaseRepository<Language>, ILanguagesRepository
    {
        public LanguagesRepository(ReviewerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
