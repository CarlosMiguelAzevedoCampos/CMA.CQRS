using CMA.CQRS.CrossCutting.EventStore;
using CMA.CQRS.CrossCutting.MemoryBus;
using CMA.CQRS.CrossCutting.Notifier;
using CMA.CQRS.Domain.Commands.Handler;
using CMA.CQRS.Domain.Commands.Model;
using CMA.CQRS.Domain.Events.Handler;
using CMA.CQRS.Domain.Events.Model;
using CMA.CQRS.Domain.Services;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Mediator;

namespace CMA.CQRS.API.Configuration
{
    public static class NativeBootStrapper
    {
        public static void InjectDependecies(this IServiceCollection services)
        {
            // Services Dependecies
            services.AddMediatR(typeof(Program));
            services.AddAutoMapper(typeof(Program));

            // Bus
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Command
            services.AddScoped<IRequestHandler<NewUserCommand, ValidationResult>, UserCommandHandler>();

            // Events
            services.AddScoped<INotificationHandler<NewUserEvent>, UserEventHandler>();

            // Services
            services.AddScoped<INotifierService, NotifierService>();

            // Event Store
            services.AddSingleton<IEventStore, EventStore>();
        }
    }
}
