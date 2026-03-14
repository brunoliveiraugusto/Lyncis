using MediatR;

namespace Lyncis.Post.Application.Users.Commands.UpdatePostAuthorName
{
    public record UpdatePostAuthorNameCommand(Guid UserId, string NewName) : IRequest;
}
