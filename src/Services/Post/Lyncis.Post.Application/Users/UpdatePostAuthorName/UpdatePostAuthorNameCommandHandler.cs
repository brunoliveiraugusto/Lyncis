using Lyncis.Post.Domain.Interfaces;
using MediatR;

namespace Lyncis.Post.Application.Users.UpdatePostAuthorName
{
    public class UpdatePostAuthorNameCommandHandler(IPostRepository repository) : IRequestHandler<UpdatePostAuthorNameCommand>
    {
        private readonly IPostRepository _repository = repository;

        public async Task Handle(UpdatePostAuthorNameCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateAuthorNameAsync(request.UserId, request.NewName);
        }
    }
}
