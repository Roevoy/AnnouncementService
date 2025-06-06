using AnnouncementService.Core.Models;
using MediatR;

namespace AnnouncementService.BLL.Queries
{
    public class GetAnnouncementsByCreatorIdQuery : IRequest<IEnumerable<Announcement>>
    {
        public string CreatorId { get; set; }
        public GetAnnouncementsByCreatorIdQuery(string creatorId)
        {
            CreatorId = creatorId;
        }
        public GetAnnouncementsByCreatorIdQuery()
        {
            
        }
    }
}
