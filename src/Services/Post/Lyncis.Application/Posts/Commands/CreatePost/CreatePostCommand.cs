using MediatR;

namespace Lyncis.Application.Posts.Commands.CreatePost
{
    public record CreatePostCommand(Guid AuthorId, string Content, List<Guid>? MediaIds) : IRequest<Guid>;
}
