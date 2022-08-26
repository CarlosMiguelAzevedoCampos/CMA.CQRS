using CMA.CQRS.Domain.Events.Model;
using CMA.CQRS.Domain.Services;
using MediatR;

namespace CMA.CQRS.Domain.Events.Handler
{
    public class UserEventHandler :
                INotificationHandler<NewUserEvent>
    {

        private readonly INotifierService _notifierService;
        private readonly IEventStore _eventStore;
        public UserEventHandler(INotifierService notifierService,
             IEventStore eventStore)
        {
            _notifierService = notifierService;
            _eventStore = eventStore;
        }

        public Task Handle(NewUserEvent notification, CancellationToken cancellationToken)
        {
            _notifierService.Notifier(string.Format("New user created! Name:{0}, Address: {1}, Creation date: {2}", 
                notification.Name,
                notification.Address,
                notification.Timestamp));
            _eventStore.AddEvent(notification);
            return Task.CompletedTask;
        }
    }
}
