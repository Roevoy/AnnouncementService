using AnnouncementService.Core.Models;
using MediatR;

namespace AnnouncementService.BLL.Queries
{
    public class GetAnnouncementsByTitleQuery : IRequest<IEnumerable<Announcement>>
    {
        public string Title { get; set; }
        public GetAnnouncementsByTitleQuery(string title)
        {
            Title = title;
        }
        public GetAnnouncementsByTitleQuery()
        {
            
        }
    }
}
