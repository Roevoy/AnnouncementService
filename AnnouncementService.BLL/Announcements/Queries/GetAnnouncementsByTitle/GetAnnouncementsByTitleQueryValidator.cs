using FluentValidation;

namespace AnnouncementService.BLL.Queries
{
    public class GetAnnouncementsByTitleQueryValidator : AbstractValidator<GetAnnouncementsByTitleQuery>
    {
        public GetAnnouncementsByTitleQueryValidator()
        {
            RuleFor(q => q.Title)
                .NotEmpty().WithMessage("Title is required.");
        }
    }
}
