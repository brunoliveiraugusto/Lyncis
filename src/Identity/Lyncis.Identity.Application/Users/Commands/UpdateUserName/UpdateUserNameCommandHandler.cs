using Lyncis.Identity.Application.Common.Interfaces;
using Lyncis.Identity.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Lyncis.Identity.Application.Users.Commands.UpdateUserName
{
    public class UpdateUserNameCommandHandler(IUserRepository repository, IIdentityEventService eventService, ILogger<UpdateUserNameCommandHandler> logger) : IRequestHandler<UpdateUserNameCommand, bool>
    {
        private readonly IUserRepository _repository = repository;
        private readonly IIdentityEventService _eventService = eventService;
        private readonly ILogger<UpdateUserNameCommandHandler> _logger = logger;

        public async Task<bool> Handle(UpdateUserNameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Initiating user update from {UserId} to {NewName}", request.UserId, request.NewName);

                var user = await _repository.GetByIdAsync(request.UserId) ?? throw new InvalidOperationException("user not found.");

                user.UpdateName(request.NewName);

                await _repository.UpdateAsync(user);

                await _eventService.PublishUserRenamedAsync(user.Id, user.Name, cancellationToken);

                return true;
            }
            catch
            {
                _logger.LogError("Error updating {UserId} to {NewName}", request.UserId, request.NewName);
                throw;
            }
        }
    }
}
