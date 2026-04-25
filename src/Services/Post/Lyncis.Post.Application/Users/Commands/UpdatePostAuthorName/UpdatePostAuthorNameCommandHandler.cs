using Lyncis.Post.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Lyncis.Post.Application.Users.Commands.UpdatePostAuthorName
{
    public class UpdatePostAuthorNameCommandHandler(IPostRepository repository, ILogger<UpdatePostAuthorNameCommandHandler> logger) : IRequestHandler<UpdatePostAuthorNameCommand>
    {
        private readonly IPostRepository _repository = repository;
        private readonly ILogger<UpdatePostAuthorNameCommandHandler> _logger = logger;

        public async Task Handle(UpdatePostAuthorNameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Initiating user update from {UserId} to {NewName}", request.UserId, request.NewName);

                await _repository.UpdateAuthorNameAsync(request.UserId, request.NewName);
            }
            catch
            {
                _logger.LogError("Error updating {UserId} to {NewName}", request.UserId, request.NewName);
                throw;
            }
        }
    }
}
