using AnnouncementService.Core.Models;
using AnnouncementService.DAL.Interfaces;
using MediatR;

namespace AnnouncementService.BLL.Queries
{
    public class GetAnnouncementByIdQueryHandler : IRequestHandler<GetAnnouncementByIdQuery, Announcement>
    {
        private readonly IAnnouncementRepository _announcementRepository;
        public GetAnnouncementByIdQueryHandler(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }
        public async Task<Announcement> Handle(GetAnnouncementByIdQuery request, CancellationToken cancellationToken)
        {
            return await _announcementRepository.GetAnnouncementByIdAsync(request.Id);
        }
    }
}
