using AnnouncementService.Core.Models;
using AnnouncementService.DAL.Interfaces;
using MediatR;

namespace AnnouncementService.BLL.Queries
{
    public class GetAnnouncementsByCreatorIdQueryHandler : IRequestHandler<GetAnnouncementsByCreatorIdQuery, IEnumerable<Announcement>>
    {
        private readonly IAnnouncementRepository _announcementRepository;
        public GetAnnouncementsByCreatorIdQueryHandler(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }
        public async Task<IEnumerable<Announcement>> Handle(GetAnnouncementsByCreatorIdQuery request, CancellationToken cancellationToken)
        {
            return await _announcementRepository.GetAnnouncementsByCreatorIdAsync(request.CreatorId);
        }
    }
}
