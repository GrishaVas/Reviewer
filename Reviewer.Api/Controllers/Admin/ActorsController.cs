using Microsoft.AspNetCore.Mvc;
using Reviewer.Infrastructure.Models;
using Reviewer.Services.Abstractions.Admin;
using Reviewer.Services.Models;
using Reviewer.Services.Models.Admin;

namespace Reviewer.Api.Controllers.Admin
{
    public class ActorsController : BaseAdminController<CreateActorRequest, UpdateActorRequest, Actor, ActorResponse, IAdminActorsService>
    {
        public ActorsController(IAdminActorsService service) : base(service)
        {
        }

        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ActorResponse))]
        public override async Task<IActionResult> Create(CreateActorRequest create)
        {
            var actor = await _service.Create(create);

            return Created(this.Url.Action(), actor);
        }

        public override async Task<IActionResult> Delete(Guid id)
        {
            await _service.Delete(id);

            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActorResponse))]
        public override async Task<IActionResult> Get(Guid id)
        {
            var actor = await _service.Get(id);

            return Ok(actor);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ActorResponse>))]
        public override async Task<IActionResult> GetList([FromQuery] RequestFilters filters)
        {
            var actors = await _service.GetList(filters);

            return Ok(actors);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActorResponse))]
        public override async Task<IActionResult> Update(UpdateActorRequest update)
        {
            var actor = await _service.Update(update);

            return Ok(actor);
        }
    }
}
