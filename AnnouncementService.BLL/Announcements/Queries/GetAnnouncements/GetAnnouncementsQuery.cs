using AnnouncementService.Core.Models;
using MediatR;

namespace AnnouncementService.BLL.Queries
{
    public class GetAnnouncementsQuery : IRequest<IEnumerable<Announcement>> { }
}
