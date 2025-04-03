using FluentValidation;
using GroupApp.Data.DTOs;

namespace GroupApp.Core.Validators;

public class ProjectValidator : AbstractValidator<ProjectDTO>
{
    public ProjectValidator()
    {
        RuleFor(p => p.OwnerId)
            .NotEmpty().WithMessage("Owner ID is required.")
            .GreaterThan(0).WithMessage("Owner ID must be greater than 0.");
        
        RuleFor(p => p.DeadLine)
            .NotEmpty().WithMessage("Deadline is required.")
            .GreaterThan(DateTime.Now).WithMessage("Deadline must be in the future.");

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Project name is required.")
            .MaximumLength(100).WithMessage("Project name cannot exceed 100 characters.");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("Project description is required.")
            .MaximumLength(500).WithMessage("Project description cannot exceed 500 characters.");
    }
}