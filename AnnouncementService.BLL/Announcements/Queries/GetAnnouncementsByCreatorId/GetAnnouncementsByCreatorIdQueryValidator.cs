using FluentValidation;

namespace AnnouncementService.BLL.Queries
{
    public class GetAnnouncementsByCreatorIdQueryValidator : AbstractValidator<GetAnnouncementsByCreatorIdQuery>
    {
        public GetAnnouncementsByCreatorIdQueryValidator()
        {
            RuleFor(q => q.CreatorId)
                .NotEmpty().WithMessage("Creator ID is required.")
                .Must(CreatorIdAsString => Guid.TryParse(CreatorIdAsString, out var creatorId) && creatorId != Guid.Empty)
                    .WithMessage("Creator ID must be a valid non-empty GUID.");
        }
    }
}
