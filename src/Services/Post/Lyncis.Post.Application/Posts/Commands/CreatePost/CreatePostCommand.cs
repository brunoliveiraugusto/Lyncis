using MediatR;

namespace Lyncis.Post.Application.Posts.Commands.CreatePost
{
    public record CreatePostCommand(Guid AuthorId, string AuthorName, string Content, List<Guid>? MediaIds) : IRequest<Guid>;
}
