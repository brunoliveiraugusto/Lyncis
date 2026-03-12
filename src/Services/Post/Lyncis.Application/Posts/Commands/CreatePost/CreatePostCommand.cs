using MediatR;

namespace Lyncis.Application.Posts.Commands.CreatePost
{
    public record CreatePostCommand(Guid AuthorId, string AuthorName, string Content, List<Guid>? MediaIds) : IRequest<Guid>;
}
