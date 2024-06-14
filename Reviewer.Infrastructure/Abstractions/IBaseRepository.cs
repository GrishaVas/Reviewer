using System.Linq.Expressions;
using Reviewer.Infrastructure.Models;

namespace Reviewer.Infrastructure.Abstractions
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        T Create(T create);
        Task<T> Update(T update);
        Task<T> Get(Guid id);
        Task<List<T>> GetEntities(Expression<Func<T, bool>> predicate);
        Task Delete(Guid id);
        IQueryable<T> GetQuery();
    }
}
