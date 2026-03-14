using MediatR;

namespace Lyncis.Identity.Application.Users.Commands.UpdateUserName
{
    public class UpdateUserNameCommandHandler : IRequestHandler<UpdateUserNameCommand>
    {
        public Task Handle(UpdateUserNameCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
