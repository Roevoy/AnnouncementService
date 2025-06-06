using AnnouncementService.DAL.Interfaces;
using MediatR;

namespace AnnouncementService.BLL.Сommands
{
    public class DeleteAnnouncementCommandHandler : IRequestHandler<DeleteAnnouncementCommand, Unit>
    {
        private readonly IAnnouncementRepository _announcementRepository;
        public DeleteAnnouncementCommandHandler(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }
        public async Task<Unit> Handle(DeleteAnnouncementCommand request, CancellationToken cancellationToken)
        {
            await _announcementRepository.DeleteAnnouncementAsync(request.Id);
            return Unit.Value;
        }
    }

}
