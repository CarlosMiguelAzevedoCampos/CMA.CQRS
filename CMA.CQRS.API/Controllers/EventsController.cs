using CMA.CQRS.Domain.Commands.Model;
using CMA.CQRS.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Messaging;

namespace CMA.CQRS.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventStore _eventStore;

        public EventsController(IEventStore eventStore)
        {
            this._eventStore = eventStore;
        }

        [HttpGet(Name = "obtain-events")]
        public ActionResult<List<Event>> Get()
        {
            var data = _eventStore.ObtainEvents();
            return Ok(new
            {
                success = true,
                data = data
            });
        }
    }
}
