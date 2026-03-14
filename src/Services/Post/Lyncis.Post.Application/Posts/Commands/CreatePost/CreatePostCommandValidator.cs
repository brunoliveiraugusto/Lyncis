using FluentValidation;

namespace Lyncis.Post.Application.Posts.Commands.CreatePost
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(x => x.AuthorId)
                .NotEmpty()
                .NotEqual(Guid.Empty)
                .WithMessage("A valid author is required");

            RuleFor(x => x.AuthorName)
                .NotEmpty().WithMessage("A valid author is required")
                .MaximumLength(200).WithMessage("Post author name must be 200 characters or less");

            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Post content cannot be empty")
                .MaximumLength(280).WithMessage("Post content must be 280 characters or less");

            RuleFor(x => x.MediaIds)
                .Must(x => x == null || x.Count <= 4)
                .WithMessage("You cannot attach more than 4 media items");
        }
    }
}
