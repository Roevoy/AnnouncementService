using AnnouncementService.Core.Models;
using MediatR;

namespace AnnouncementService.BLL.Queries
{
    public class GetAnnouncementByIdQuery : IRequest<Announcement>
    {
        public Guid Id { get; set; }
        public GetAnnouncementByIdQuery(Guid id)
        {
            Id = id;
        }
        public GetAnnouncementByIdQuery() { }
    }
}
