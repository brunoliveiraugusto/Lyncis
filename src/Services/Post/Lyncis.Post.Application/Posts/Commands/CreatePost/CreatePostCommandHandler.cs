using Lyncis.Post.Domain.Factories;
using Lyncis.Post.Domain.Interfaces;
using MediatR;

namespace Lyncis.Post.Application.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler(IPostRepository repository) : IRequestHandler<CreatePostCommand, Guid>
    {
        private readonly IPostRepository _repository = repository;

        public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = PostFactory.Create(request.AuthorId, request.AuthorName, request.Content, request.MediaIds);
            
            await _repository.AddAsync(post);

            return post.Id;
        }
    }
}
