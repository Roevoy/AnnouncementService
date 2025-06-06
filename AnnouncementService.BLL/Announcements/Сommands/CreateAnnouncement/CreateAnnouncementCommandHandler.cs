using AnnouncementService.Core.Models;
using AnnouncementService.DAL.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AnnouncementService.BLL.Сommands
{
    public class CreateAnnouncementCommandHandler : IRequestHandler<CreateAnnouncementCommand, Unit>
    {
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly UserManager<IdentityUser> _userManager;
        public CreateAnnouncementCommandHandler(IAnnouncementRepository announcementRepository, UserManager<IdentityUser> userManager)
        {
            _announcementRepository = announcementRepository;
            _userManager = userManager;
        }
        public async Task<Unit> Handle(CreateAnnouncementCommand request, CancellationToken cancellationToken)
        {
            var announcement = new Announcement
            {
                Id = Guid.NewGuid(),
                CreatorId = request.CreatorId,
                Title = request.Title,
                Description = request.Description,
                DateAdded = DateTime.UtcNow,
                DateUpdated = null
            };
            await _announcementRepository.CreateAnnouncementAsync(announcement);
            return Unit.Value;
        }
    }

}
