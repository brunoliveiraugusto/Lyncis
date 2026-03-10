using Lyncis.Domain.Factories;
using Lyncis.Domain.Interfaces;
using MediatR;

namespace Lyncis.Application.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler(IPostRepository repository) : IRequestHandler<CreatePostCommand, Guid>
    {
        private readonly IPostRepository _repository = repository;

        public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = PostFactory.Create(request.AuthorId, request.Content, request.MediaIds);
            
            await _repository.AddAsync(post);

            return post.Id;
        }
    }
}
