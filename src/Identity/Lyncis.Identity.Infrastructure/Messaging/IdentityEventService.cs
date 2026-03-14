using Lyncis.Identity.Application.Common.Interfaces;
using Lyncis.Identity.Contracts;
using MassTransit;

namespace Lyncis.Identity.Infrastructure.Messaging
{
    internal class IdentityEventService(IPublishEndpoint publishEndpoint) : IIdentityEventService
    {
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        public async Task PublishUserRenamedAsync(Guid userId, string newName, CancellationToken ct = default)
        {
            await _publishEndpoint.Publish(new UserRenamedEvent(
                userId,
                newName,
                DateTime.UtcNow
            ), ct);
        }
    }
}
