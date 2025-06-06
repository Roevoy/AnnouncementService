using FluentValidation;

namespace AnnouncementService.BLL.Сommands
{
    public class DeleteAnnouncementCommandValidator : AbstractValidator<DeleteAnnouncementCommand>
    {
        public DeleteAnnouncementCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("ID is required.");
        }
    }
}
