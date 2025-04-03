using FluentValidation;
using GroupApp.Data.DTOs;

namespace GroupApp.Core.Validators;

public class UserValidator : AbstractValidator<UserDTO>
{
    public UserValidator()
    {
        RuleFor(u => u.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(2, 50).WithMessage("Name must be between 2 and 50 characters long.");

        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.")
            .Length(5, 100).WithMessage("Email must be between 5 and 100 characters long.");

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("Password is required.")
            .Length(6, 100).WithMessage("Password must be between 6 and 100 characters long.");

        RuleFor(u => u.RoleId)
            .NotEmpty().WithMessage("Role ID is required.")
            .GreaterThan(0).WithMessage("Role ID must be greater than 0.");
    }
}