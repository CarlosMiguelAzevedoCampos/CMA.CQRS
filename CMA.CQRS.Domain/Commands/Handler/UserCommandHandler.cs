using CMA.CQRS.Domain.Commands.Model;
using CMA.CQRS.Domain.Events.Model;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Mediator;
using NetDevPack.Messaging;

namespace CMA.CQRS.Domain.Commands.Handler
{
    public class UserCommandHandler : CommandHandler,
                IRequestHandler<NewUserCommand, ValidationResult>
    {
        private readonly IMediatorHandler _mediator;

        public UserCommandHandler(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        public async Task<ValidationResult> Handle(NewUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) 
                return request.ValidationResult;

            await _mediator.PublishEvent(new NewUserEvent(request.Name, request.Address, request.AggregateId));
            
            return await Task.FromResult(ValidationResult);
        }
    }
}
