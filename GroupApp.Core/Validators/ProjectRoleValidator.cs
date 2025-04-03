using FluentValidation;
using GroupApp.Data.DTOs;

namespace GroupApp.Core.Validators;

public class ProjectRoleValidator : AbstractValidator<ProjectRoleDTO>
{
    public ProjectRoleValidator()
    {
        RuleFor(pr => pr.ProjectId)
            .NotEmpty().WithMessage("Project ID is required.")
            .GreaterThan(0).WithMessage("Project ID must be greater than 0.");

        RuleFor(pr => pr.UserId)
            .NotEmpty().WithMessage("User ID is required.")
            .GreaterThan(0).WithMessage("User ID must be greater than 0.");

        RuleFor(pr => pr.Name)
            .NotEmpty().WithMessage("Role name is required.")
            .MaximumLength(50).WithMessage("Role name cannot exceed 50 characters.");
        
        RuleFor(pr => pr.Description)
            .NotEmpty().WithMessage("Role description is required.")
            .MaximumLength(200).WithMessage("Role description cannot exceed 200 characters.");
    }
}