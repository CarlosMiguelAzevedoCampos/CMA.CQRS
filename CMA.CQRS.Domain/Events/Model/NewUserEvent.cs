using NetDevPack.Messaging;

namespace CMA.CQRS.Domain.Events.Model
{
    public class NewUserEvent : Event
    {
        public NewUserEvent(string name, string address, Guid aggregateId)
        {
            Name = name;
            Address = address;
            AggregateId = aggregateId;
        }

        public string Name { get; set; }
        public string Address { get; set; }
    }
}
