using Lyncis.Identity.Application.Common.Interfaces;
using Lyncis.Identity.Domain.Interfaces;
using MediatR;

namespace Lyncis.Identity.Application.Users.Commands.UpdateUserName
{
    public class UpdateUserNameCommandHandler(IUserRepository repository, IIdentityEventService eventService) : IRequestHandler<UpdateUserNameCommand, bool>
    {
        private readonly IUserRepository _repository = repository;
        private readonly IIdentityEventService _eventService = eventService;

        public async Task<bool> Handle(UpdateUserNameCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.UserId) ?? throw new InvalidOperationException("user not found.");

            user.UpdateName(request.NewName);

            await _repository.UpdateAsync(user);

            await _eventService.PublishUserRenamedAsync(user.Id, user.Name);

            return true;
        }
    }
}
