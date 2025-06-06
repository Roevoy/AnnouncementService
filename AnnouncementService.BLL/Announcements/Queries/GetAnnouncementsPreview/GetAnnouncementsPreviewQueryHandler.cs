using AnnouncementService.DAL.Interfaces;
using AnnouncementService.Shared.DTOs;
using MediatR;

namespace AnnouncementService.BLL.Queries
{
    public class GetAnnouncementsPreviewQueryHandler : IRequestHandler<GetAnnouncementsPreviewQuery, IEnumerable<AnnouncementPreviewDto>>
    {
        private readonly IAnnouncementRepository _announcementRepository;
        public GetAnnouncementsPreviewQueryHandler(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }
        public async Task<IEnumerable<AnnouncementPreviewDto>> Handle(GetAnnouncementsPreviewQuery request, CancellationToken cancellationToken)
        {
            return await _announcementRepository.GetAnnouncementsPreviewAsync();
        }
    }
}
