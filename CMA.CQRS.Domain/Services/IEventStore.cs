using CMA.CQRS.Domain.Events.Model;
using NetDevPack.Messaging;

namespace CMA.CQRS.Domain.Services
{
    public interface IEventStore
    {
        void AddEvent(Event @event);
        ICollection<Event> ObtainEvents();
    }
}
