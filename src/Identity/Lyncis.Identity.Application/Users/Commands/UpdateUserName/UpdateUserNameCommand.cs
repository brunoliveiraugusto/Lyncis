using MediatR;

namespace Lyncis.Identity.Application.Users.Commands.UpdateUserName
{
    public record UpdateUserNameCommand(Guid UserId, string NewName) : IRequest;
}
