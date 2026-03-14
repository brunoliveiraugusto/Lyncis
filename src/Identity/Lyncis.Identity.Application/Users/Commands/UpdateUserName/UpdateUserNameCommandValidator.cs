using FluentValidation;

namespace Lyncis.Identity.Application.Users.Commands.UpdateUserName
{
    public class UpdateUserNameCommandValidator : AbstractValidator<UpdateUserNameCommand>
    {
        public UpdateUserNameCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotEqual(Guid.Empty)
                .WithMessage("A valid user is required");

            RuleFor(x => x.NewName)
                .NotEmpty().WithMessage("A valid name is required")
                .MaximumLength(200).WithMessage("New name must be 200 characters or less");
        }
    }
}
