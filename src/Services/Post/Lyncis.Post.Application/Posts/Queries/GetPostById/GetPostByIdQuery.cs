using MediatR;

namespace Lyncis.Post.Application.Posts.Queries.GetPostById
{
    public record GetPostByIdQuery(Guid Id) : IRequest<PostResponse>;

    public record PostResponse(Guid Id, Guid AuthorId, string AuthorName, string Content, DateTime CreatedAt)
    {
        public static PostResponse FromDomain(Domain.Entities.Post post) => new(post.Id, post.AuthorId, post.AuthorName, post.Content, post.CreatedAt);
    }
}
