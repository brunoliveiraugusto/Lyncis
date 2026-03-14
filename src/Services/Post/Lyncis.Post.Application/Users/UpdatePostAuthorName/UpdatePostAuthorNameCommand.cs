using MediatR;

namespace Lyncis.Post.Application.Users.UpdatePostAuthorName
{
    public record UpdatePostAuthorNameCommand(Guid UserId, string NewName) : IRequest;
}
