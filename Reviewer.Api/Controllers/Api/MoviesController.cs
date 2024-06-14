using Microsoft.AspNetCore.Mvc;
using Reviewer.Services.Abstractions.Api;
using Reviewer.Services.Models;
using Reviewer.Services.Models.Api;

namespace Reviewer.Api.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;
        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MovieDetails>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMovies([FromQuery] RequestFilters filters)
        {
            var movies = await _moviesService.GetMovies(filters);

            return Ok(movies);
        }
    }
}
