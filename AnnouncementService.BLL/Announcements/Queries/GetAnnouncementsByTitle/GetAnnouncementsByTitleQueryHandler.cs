using AnnouncementService.Core.Models;
using AnnouncementService.DAL.Interfaces;
using MediatR;

namespace AnnouncementService.BLL.Queries
{
    public class GetAnnouncementsByTitleQueryHandler : IRequestHandler<GetAnnouncementsByTitleQuery, IEnumerable<Announcement>>
    {
        private readonly IAnnouncementRepository _announcementRepository;
        public GetAnnouncementsByTitleQueryHandler(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }
        public async Task<IEnumerable<Announcement>> Handle(GetAnnouncementsByTitleQuery query, CancellationToken cancellationToken) 
        {
            return await _announcementRepository.GetAnnouncementsByTitleAsync(query.Title);
        }
    }
}
