using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Reviewer.Infrastructure.Abstractions;
using Reviewer.Infrastructure.Models;
using Reviewer.Services.Models;

namespace Reviewer.Services.Abstractions.Admin
{
    public abstract class BaseAdminService<TCreate, TUpdate, T, TResponse>
        where TCreate : class
        where TUpdate : class
        where T : BaseModel
        where TResponse : class
    {
        protected IBaseRepository<T> _repository;
        protected IMapper _mapper;
        protected IUnitOfWork _unitOfWork;

        protected BaseAdminService(IBaseRepository<T> repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<TResponse> Create(TCreate create)
        {
            var entity = _mapper.Map<T>(create);

            _repository.Create(entity);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<TResponse>(entity);
        }
        public virtual async Task<TResponse> Update(TUpdate update)
        {
            var entity = _mapper.Map<T>(update);

            await _repository.Update(entity);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<TResponse>(entity);
        }
        public virtual async Task<TResponse> Get(Guid id)
        {
            var entity = await _repository.Get(id);

            return _mapper.Map<TResponse>(entity);
        }
        public virtual async Task<List<TResponse>> GetList(RequestFilters filters, Expression<Func<T, bool>> predicate = null)
        {
            if (filters == null)
            {
                filters = new RequestFilters
                {
                    Count = 5,
                    Page = 0
                };
            }

            var entities = await (predicate != null ?
                    _repository.GetQuery()
                    .Where(predicate) :
                    _repository.GetQuery()
                 )
                .ProjectTo<TResponse>(_mapper.ConfigurationProvider)
                .Skip(filters.Page * filters.Count)
                .Take(filters.Count)
                .ToListAsync();

            return entities;
        }
        public virtual async Task Delete(Guid id)
        {
            await _repository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
