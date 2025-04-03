namespace GroupApp.Core.Validators;
using FluentValidation;
using GroupApp.Data.DTOs;

public class TaskCommentValidator : AbstractValidator<TaskCommentDTO>
{
    public TaskCommentValidator()
    {
        RuleFor(tc => tc.Content)
            .NotEmpty().WithMessage("Comment text is required.")
            .MaximumLength(500).WithMessage("Comment text cannot exceed 500 characters.");

        RuleFor(tc => tc.TaskId)
            .NotEmpty().WithMessage("Task ID is required.")
            .GreaterThan(0).WithMessage("Task ID must be greater than 0.");

        RuleFor(tc => tc.UserId)
            .NotEmpty().WithMessage("User ID is required.")
            .GreaterThan(0).WithMessage("User ID must be greater than 0.");
    }
}