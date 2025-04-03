using FluentValidation;
using GroupApp.Data.DTOs;

namespace GroupApp.Core.Validators;

public class RoleValidator : AbstractValidator<RoleDTO>
{
    public RoleValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty().WithMessage("Role name is required.")
            .Length(2, 50).WithMessage("Role name must be between 2 and 50 characters long.");
        
        RuleFor(r => r.Description)
            .NotEmpty().WithMessage("Role description is required.")
            .Length(10, 200).WithMessage("Role description must be between 10 and 200 characters long.");
    }
}