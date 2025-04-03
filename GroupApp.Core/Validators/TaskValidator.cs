using FluentValidation;
using GroupApp.Data.DTOs;

namespace GroupApp.Core.Validators;

public class TaskValidator : AbstractValidator<TaskDTO>
{
    public TaskValidator()
    {
        RuleFor(t => t.Name)
            .NotEmpty().WithMessage("Task title is required.")
            .Length(2, 100).WithMessage("Task title must be between 2 and 100 characters long.");

        RuleFor(t => t.Description)
            .NotEmpty().WithMessage("Task description is required.")
            .Length(10, 500).WithMessage("Task description must be between 10 and 500 characters long.");

        RuleFor(t => t.DueDate)
            .NotEmpty().WithMessage("Due date is required.")
            .GreaterThan(DateTime.Now).WithMessage("Due date must be in the future.");

        RuleFor(t => t.AssignedUserId)
            .NotEmpty().WithMessage("Assigned user ID is required.")
            .GreaterThan(0).WithMessage("Assigned user ID must be greater than 0.");
    }
}