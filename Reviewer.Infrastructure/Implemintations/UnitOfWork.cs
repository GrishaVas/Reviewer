using Reviewer.Infrastructure.Abstractions;

namespace Reviewer.Infrastructure.Implemintations
{
    public class UnitOfWork : IUnitOfWork
    {
        private ReviewerDbContext _dbContext;

        public UnitOfWork(ReviewerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
