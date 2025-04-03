using FluentValidation;
using GroupApp.Data.DTOs;

namespace GroupApp.Core.Validators;

public class ProjectRelValidator : AbstractValidator<ProjectRelDTO>
{
    public ProjectRelValidator()
    {
        RuleFor(pr => pr.ProjectId)
            .NotEmpty().WithMessage("Project ID is required.")
            .GreaterThan(0).WithMessage("Project ID must be greater than 0.");

        RuleFor(pr => pr.UserId)
            .NotEmpty().WithMessage("User ID is required.")
            .GreaterThan(0).WithMessage("Related Project ID must be greater than 0.");
    }
}