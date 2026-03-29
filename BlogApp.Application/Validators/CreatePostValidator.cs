using BlogApp.Application.DTOs.Post;
using FluentValidation;

namespace BlogApp.Application.Validators;

public class CreatePostValidator : AbstractValidator<CreatePostDto>
{
	public CreatePostValidator()
	{
		RuleFor(x => x.Title)
			.NotEmpty().WithMessage("Title is required")
			.MaximumLength(100).WithMessage("Title must not exceed 100 characters");

		RuleFor(x => x.Content)
			.NotEmpty().WithMessage("Content is required");

		RuleFor(x => x.CategoryId)
			.GreaterThan(0).WithMessage("Category is required");
	}
}