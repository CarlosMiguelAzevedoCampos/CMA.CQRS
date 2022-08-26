using CMA.CQRS.Domain.Services;

namespace CMA.CQRS.CrossCutting.Notifier
{
    public class NotifierService : INotifierService
    {
        public void Notifier(string message)
        {
            Console.WriteLine(message);
        }
    }
}