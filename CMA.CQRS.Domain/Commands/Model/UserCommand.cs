using NetDevPack.Messaging;

namespace CMA.CQRS.Domain.Commands.Model
{
    public class UserCommand : Command
    {
        public UserCommand(string name, string address)
        {
            Name = name;
            Address = address;
            AggregateId = Guid.NewGuid();
        }

        public string Name { get; set; }
        public string Address { get; set; }
    }
}
