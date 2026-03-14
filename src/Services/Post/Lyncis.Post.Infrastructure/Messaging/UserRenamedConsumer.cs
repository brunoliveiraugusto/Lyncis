using Lyncis.Identity.Contracts;
using Lyncis.Post.Infrastructure.Persistence;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Lyncis.Post.Infrastructure.Messaging
{
    public class UserRenamedConsumer(PostDbContext context, ILogger<UserRenamedConsumer> logger) : IConsumer<UserRenamedEvent>
    {
        private readonly PostDbContext _context = context;
        private readonly ILogger<UserRenamedConsumer> _logger = logger;

        public async Task Consume(ConsumeContext<UserRenamedEvent> context)
        {
            var message = context.Message;
            _logger.LogInformation("Updating posts for user {UserId} to new name {NewName}", message.UserId, message.NewName);

            await _context.Posts
                .Where(p => p.AuthorId == message.UserId)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(p => p.AuthorName, message.NewName));
        }
    }
}
