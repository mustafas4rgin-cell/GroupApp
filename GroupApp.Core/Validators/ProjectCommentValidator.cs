using FluentValidation;
using GroupApp.Data.DTOs;

namespace GroupApp.Core.Validators;

public class ProjectCommentValidator : AbstractValidator<ProjectCommentDTO>
{
    public ProjectCommentValidator()
    {
        RuleFor(pc => pc.Content)
            .NotEmpty().WithMessage("Comment text is required.")
            .MaximumLength(500).WithMessage("Comment text cannot exceed 500 characters.");

        RuleFor(pc => pc.ProjectId)
            .NotEmpty().WithMessage("Project ID is required.")
            .GreaterThan(0).WithMessage("Project ID must be greater than 0.");

        RuleFor(pc => pc.UserId)
            .NotEmpty().WithMessage("User ID is required.")
            .GreaterThan(0).WithMessage("User ID must be greater than 0.");
    }
}