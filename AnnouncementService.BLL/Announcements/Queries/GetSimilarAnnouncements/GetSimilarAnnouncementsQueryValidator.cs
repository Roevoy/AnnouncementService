using FluentValidation;

namespace AnnouncementService.BLL.Announcements.Queries.GetSimilarAnnouncements
{
    public class GetSimilarAnnouncementsQueryValidator : AbstractValidator<GetSimilarAnnouncementsQuery>
    {
        public GetSimilarAnnouncementsQueryValidator()
        {
            RuleFor(x => x.ExapmleId)
                .NotEmpty().WithMessage("Example ID must not be empty.");

            RuleFor(x => x.Count)
                .NotEmpty().WithMessage("Count must not be empty.")
                .GreaterThan(0).WithMessage("Count must be greater than 0.")
                .LessThanOrEqualTo(50).WithMessage("Count must be less than or equal to 50.");
        }
    }

}
