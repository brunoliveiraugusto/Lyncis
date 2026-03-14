using Lyncis.Identity.Contracts;
using Lyncis.Post.Application.Users.UpdatePostAuthorName;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Lyncis.Post.Infrastructure.Messaging
{
    public class UserRenamedConsumer(ISender mediator, ILogger<UserRenamedConsumer> logger) : IConsumer<UserRenamedEvent>
    {
        private readonly ISender _mediator = mediator;
        private readonly ILogger<UserRenamedConsumer> _logger = logger;

        public async Task Consume(ConsumeContext<UserRenamedEvent> context)
        {
            var message = context.Message;
            var command = new UpdatePostAuthorNameCommand(message.UserId, message.NewName);

            _logger.LogInformation("Updating posts for user {UserId} to new name {NewName}", message.UserId, message.NewName);

            await _mediator.Send(command);
        }
    }
}
