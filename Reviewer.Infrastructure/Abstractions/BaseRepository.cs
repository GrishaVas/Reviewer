using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Reviewer.Infrastructure.Models;

namespace Reviewer.Infrastructure.Abstractions
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected ReviewerDbContext _dbContext { get; set; }

        protected BaseRepository(ReviewerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T Create(T create)
        {
            _dbContext.Set<T>().Add(create);

            return create;
        }

        public virtual async Task<T> Update(T update)
        {
            var enitity = await _dbContext.Set<T>().FindAsync(update.Id);

            if (enitity == null)
            {
                throw new ArgumentException($"Cannot find entity: {typeof(T)}!");
            }

            _dbContext.Set<T>().Update(update);

            return update;
        }

        public virtual Task<T> Get(Guid id)
        {
            return _dbContext.Set<T>().FindAsync(id).AsTask();
        }

        public virtual Task<List<T>> GetEntities(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual async Task Delete(Guid id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);

            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
            }
        }

        public virtual IQueryable<T> GetQuery()
        {
            return _dbContext.Set<T>().AsQueryable();
        }
    }
}
