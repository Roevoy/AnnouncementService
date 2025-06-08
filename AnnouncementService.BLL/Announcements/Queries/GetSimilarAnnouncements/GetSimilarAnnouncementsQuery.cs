using AnnouncementService.Core.Models;
using MediatR;

namespace AnnouncementService.BLL.Announcements.Queries
{
    public class GetSimilarAnnouncementsQuery : IRequest<IEnumerable<Announcement>>
    {
        public Guid ExapmleId { get; }
        public int Count { get; }
        public GetSimilarAnnouncementsQuery(Guid exapmleId, int count = 3)
        {
            ExapmleId = exapmleId;
            Count = count;
        }
    }
}
