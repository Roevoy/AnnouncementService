using FluentValidation;

namespace AnnouncementService.BLL.Users.Commands
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(c => c.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(2).WithMessage("Username must be at least 2 characters long.")
                .MaximumLength(50).WithMessage("Username must not exceed 50 characters.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
                .MaximumLength(100).WithMessage("Password must not exceed 100 characters.");
        }
    }
}
