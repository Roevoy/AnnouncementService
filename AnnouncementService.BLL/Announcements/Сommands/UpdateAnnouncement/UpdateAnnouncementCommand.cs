using MediatR;

namespace AnnouncementService.BLL.Сommands
{
    public class UpdateAnnouncementCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string? NewTitle { get; set; }
        public string? NewDescription { get; set; }
        public UpdateAnnouncementCommand(Guid id, string? newTitle = null, string? newDescription = null)
        {
            Id = id;
            NewTitle = newTitle;
            NewDescription = newDescription;
        }
    }
}
