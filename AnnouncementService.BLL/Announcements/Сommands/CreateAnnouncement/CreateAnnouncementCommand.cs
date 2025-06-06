using MediatR;
using System.Text.Json.Serialization;

namespace AnnouncementService.BLL.Сommands
{
    public class CreateAnnouncementCommand : IRequest<Unit>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        [JsonIgnore] //For security reasons
        public string? CreatorId { get; set; } = null!;
        public CreateAnnouncementCommand(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
