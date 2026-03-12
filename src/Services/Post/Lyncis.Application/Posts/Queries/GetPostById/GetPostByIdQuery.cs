using Lyncis.Domain.Entities;
using MediatR;

namespace Lyncis.Application.Posts.Queries.GetPostById
{
    public record GetPostByIdQuery(Guid Id) : IRequest<PostResponse>;

    public record PostResponse(Guid Id, Guid AuthorId, string Content, DateTime CreatedAt)
    {
        public static PostResponse FromDomain(Post post) => new(post.Id, post.AuthorId, post.Content, post.CreatedAt);
    }
}
