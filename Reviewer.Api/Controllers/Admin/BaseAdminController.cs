using Microsoft.AspNetCore.Mvc;
using Reviewer.Infrastructure.Models;
using Reviewer.Services.Abstractions.Admin;
using Reviewer.Services.Models;

namespace Reviewer.Api.Controllers.Admin
{
    [ApiController]
    [Route("admin/[controller]")]
    public abstract class BaseAdminController<TCreate, TUpdate, T, TResponse, TAdminService> : ControllerBase
        where TCreate : class
        where TUpdate : class
        where TAdminService : IBaseAdminService<TCreate, TUpdate, T, TResponse>
        where TResponse : class
        where T : BaseModel
    {
        protected TAdminService _service;

        protected BaseAdminController(TAdminService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> Create(TCreate create)
        {
            var entity = await _service.Create(create);

            return Created(this.Url.Action(), entity);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> Update(TUpdate update)
        {
            var entity = await _service.Update(update);

            return Ok(entity);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> Get(Guid id)
        {
            var entity = await _service.Get(id);

            return Ok(entity);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            await _service.Delete(id);

            return NoContent();
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> GetList([FromQuery] RequestFilters filters)
        {
            var entity = await _service.GetList(filters);

            return Ok(entity);
        }
    }
}
