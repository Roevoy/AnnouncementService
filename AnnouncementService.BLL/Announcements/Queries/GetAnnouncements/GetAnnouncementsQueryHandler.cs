using AnnouncementService.Core.Models;
using AnnouncementService.DAL.Interfaces;
using MediatR;

namespace AnnouncementService.BLL.Queries
{
    public class GetAnnouncementsQueryHandler : IRequestHandler<GetAnnouncementsQuery, IEnumerable<Announcement>>
    {
        private readonly IAnnouncementRepository _announcementRepository;
        public GetAnnouncementsQueryHandler(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }
        public async Task<IEnumerable<Announcement>> Handle(GetAnnouncementsQuery query, CancellationToken cancellationToken)
        {
            return await _announcementRepository.GetAnnouncementsAsync();
        }
    }
}
