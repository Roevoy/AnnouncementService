using FluentValidation;

namespace AnnouncementService.BLL.Сommands.UpdateAnnouncement
{
    public class UpdateAnnouncementCommandValidator : AbstractValidator<UpdateAnnouncementCommand>
    {
        public UpdateAnnouncementCommandValidator()
        {
            RuleFor(c => c)
                .Must(c => !string.IsNullOrEmpty(c.NewTitle) || !string.IsNullOrEmpty(c.NewDescription))
                .WithMessage("At least one of the fields (NewTitle or NewDescription) must be provided.");

            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("ID is required.");

            RuleFor(c => c.NewTitle)
                .Length(2, 50).WithMessage("Title length must be between 2 and 50 symbols.")
                .When(c => !string.IsNullOrEmpty(c.NewTitle));

            RuleFor(c => c.NewDescription)
                .Length(2, 5000).WithMessage("Description length must be between 2 and 5000 symbols.")
                .When(c => !string.IsNullOrEmpty(c.NewDescription));
        }
    }
}
