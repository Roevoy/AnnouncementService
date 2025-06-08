using AnnouncementService.Shared.DTOs;
using MediatR;

namespace AnnouncementService.BLL.Queries
{
    public class GetLiteAnnouncementsQuery : IRequest<IEnumerable<AnnouncementLiteDto>> { }
}
