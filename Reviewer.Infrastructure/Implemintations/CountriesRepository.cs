using Reviewer.Infrastructure.Abstractions;
using Reviewer.Infrastructure.Models;

namespace Reviewer.Infrastructure.Implemintations
{
    public class CountriesRepository : BaseRepository<Country>, ICountriesRepository
    {
        public CountriesRepository(ReviewerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
