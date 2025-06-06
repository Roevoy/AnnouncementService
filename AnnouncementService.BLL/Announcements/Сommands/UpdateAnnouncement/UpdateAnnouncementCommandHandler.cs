using AnnouncementService.DAL.Interfaces;
using MediatR;

namespace AnnouncementService.BLL.Сommands
{
    public class UpdateAnnouncementCommandHandler : IRequestHandler<UpdateAnnouncementCommand, Unit>
    {
        private readonly IAnnouncementRepository _announcementRepository;
        public UpdateAnnouncementCommandHandler(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }
        public async Task<Unit> Handle(UpdateAnnouncementCommand request, CancellationToken cancellationToken)
        {
            var announcement = await _announcementRepository.GetAnnouncementByIdAsync(request.Id);

            if (request.NewTitle is not null)
            {
                announcement.Title = request.NewTitle;
            }
            if (request.NewDescription is not null)
            {
                announcement.Description = request.NewDescription;
            }

            announcement.DateUpdated = DateTime.UtcNow;
            await _announcementRepository.UpdateAnnouncementAsync(announcement);
            return Unit.Value;
        }
    }
}
