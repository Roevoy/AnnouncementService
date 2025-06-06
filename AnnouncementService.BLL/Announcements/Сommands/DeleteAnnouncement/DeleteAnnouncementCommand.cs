using MediatR;

namespace AnnouncementService.BLL.Сommands
{
    public class DeleteAnnouncementCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public DeleteAnnouncementCommand(Guid id)
        {
            Id = id;
        }
        public DeleteAnnouncementCommand() { } //for correct query parameters binding
    }
}
