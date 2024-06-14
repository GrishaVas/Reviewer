using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Reviewer.Infrastructure.Abstractions;
using Reviewer.Infrastructure.Models;
using Reviewer.Services.Abstractions.Api;
using Reviewer.Services.Models;
using Reviewer.Services.Models.Api;

namespace Reviewer.Services.Implemintations.Api
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly IMapper _mapper;

        public MoviesService(IMoviesRepository moviesRepository, IMapper mapper)
        {
            _moviesRepository = moviesRepository;
            _mapper = mapper;
        }

        public async Task<List<MovieDetails>> GetMovies(RequestFilters filters)
        {
            var prop = typeof(Movie).GetProperty(filters.Order.OrderBy);
            var param = Expression.Parameter(typeof(Movie));
            var exp = Expression.Property(param, prop);
            var delegateType = typeof(Func<,>).MakeGenericType(typeof(Movie), prop.PropertyType);
            var lambda = Expression.Lambda(delegateType, exp, param);

            var moviesQuery = _moviesRepository.GetQuery();

            moviesQuery = filters.Search != null ? moviesQuery.Where(m => m.Name.ToLower().Contains(filters.Search.ToLower())) : moviesQuery;

            var queryableMethods = typeof(Queryable).GetMethods();
            var orderBy = queryableMethods.Single(m => m.Name == "OrderBy" && m.GetParameters().Length == 2);
            var orderByDescending = queryableMethods.Single(m => m.Name == "OrderByDescending" && m.GetParameters().Length == 2);


            moviesQuery = prop != null ?
                filters.Order.IsDescending ?
                    (IOrderedQueryable<Movie>)orderByDescending
                        .MakeGenericMethod(typeof(Movie), prop.PropertyType)
                        .Invoke(null, new object[] { moviesQuery, lambda }) :
                    (IOrderedQueryable<Movie>)orderBy
                        .MakeGenericMethod(typeof(Movie), prop.PropertyType)
                        .Invoke(null, new object[] { moviesQuery, lambda }) :
                moviesQuery;

            var movies = await moviesQuery
                .ProjectTo<MovieDetails>(_mapper.ConfigurationProvider)
                .Skip(filters.Page * filters.Count)
                .Take(filters.Count)
                .ToListAsync();

            return movies;
        }
    }
}
