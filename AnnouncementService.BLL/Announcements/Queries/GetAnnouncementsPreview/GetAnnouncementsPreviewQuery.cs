using AnnouncementService.Shared.DTOs;
using MediatR;

namespace AnnouncementService.BLL.Queries
{
    public class GetAnnouncementsPreviewQuery : IRequest<IEnumerable<AnnouncementPreviewDto>> { }
}
