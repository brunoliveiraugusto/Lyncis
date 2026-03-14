using FluentValidation;

namespace Lyncis.Post.Application.Users.UpdatePostAuthorName
{
    public class UpdatePostAuthorNameCommandValidator : AbstractValidator<UpdatePostAuthorNameCommand>
    {
        public UpdatePostAuthorNameCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotEqual(Guid.Empty)
                .WithMessage("A valid user is required");

            RuleFor(x => x.NewName)
                .NotEmpty().WithMessage("A valid new name is required")
                .MaximumLength(200).WithMessage("New name must be 200 characters or less");
        }
    }
}
