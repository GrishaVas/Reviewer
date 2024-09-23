using Reviewer.Infrastructure.Models;
using Reviewer.Services.Models;

namespace Reviewer.Services.Abstractions.Admin
{
    public interface IBaseAdminService<TCreate, TUpdate, T, TResponse>
        where TCreate : class
        where TUpdate : class
        where T : BaseModel
        where TResponse : class
    {
        Task<TResponse> Create(TCreate create);
        Task<TResponse> Update(TUpdate update);
        Task<TResponse> Get(Guid id);
        Task<ListData<TResponse>> GetList(RequestFilters filters);
        Task Delete(Guid id);
    }
}
