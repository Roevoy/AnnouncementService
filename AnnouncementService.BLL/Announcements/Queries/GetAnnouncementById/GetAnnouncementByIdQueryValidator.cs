using FluentValidation;

namespace AnnouncementService.BLL.Queries
{
    public class GetAnnouncementByIdQueryValidator : AbstractValidator<GetAnnouncementByIdQuery>
    {
        public GetAnnouncementByIdQueryValidator()
        {
            RuleFor(q => q.Id)
                .NotEmpty().WithMessage("ID is required.");
        }
    }
}
