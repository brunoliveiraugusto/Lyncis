using Lyncis.Domain.Interfaces;
using MediatR;

namespace Lyncis.Application.Posts.Queries.GetPostById
{
    public class GetPostByIdQueryHandler(IPostRepository repository) : IRequestHandler<GetPostByIdQuery, PostResponse?>
    {
        private readonly IPostRepository _repository = repository;

        public async Task<PostResponse?> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var post = await _repository.GetByIdAsync(request.Id);

            if (post is null) return null;

            return PostResponse.FromDomain(post);
        }
    }
}
