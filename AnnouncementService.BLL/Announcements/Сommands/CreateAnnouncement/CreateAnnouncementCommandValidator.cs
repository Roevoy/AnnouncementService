using FluentValidation;

namespace AnnouncementService.BLL.Сommands
{
    public class CreateAnnouncementCommandValidator : AbstractValidator<CreateAnnouncementCommand>
    {
        public CreateAnnouncementCommandValidator()
        {
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("Title is required.")
                .Length(2, 50).WithMessage("Title length must be between 2 and 50 symbols.");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Description is required.")
                .Length(2, 5000).WithMessage("Title length must be between 2 and 5000 symbols.");

            RuleFor(c => c.CreatorId)
                .NotEmpty().WithMessage("Creator ID is required.")
                .When(c => c.CreatorId is not null)
                .Must(CreatorIdAsString => Guid.TryParse(CreatorIdAsString, out var creatorId) && creatorId != Guid.Empty)
                    .WithMessage("Creator ID must be a valid non-empty GUID.")
                    .When(c => c.CreatorId is not null);
        }
    }
}
