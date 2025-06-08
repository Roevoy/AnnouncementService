using AnnouncementService.DAL.Interfaces;
using AnnouncementService.Shared.DTOs;
using MediatR;

namespace AnnouncementService.BLL.Queries
{
    public class GetLiteAnnouncementsQueryHandler : IRequestHandler<GetLiteAnnouncementsQuery, IEnumerable<AnnouncementLiteDto>>
    {
        private readonly IAnnouncementRepository _announcementRepository;
        public GetLiteAnnouncementsQueryHandler(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }
        public async Task<IEnumerable<AnnouncementLiteDto>> Handle(GetLiteAnnouncementsQuery request, CancellationToken cancellationToken)
        {
            return await _announcementRepository.GetLiteAnnouncementsAsync();
        }
    }
}
