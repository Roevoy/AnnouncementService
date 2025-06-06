using AnnouncementService.Core.Models;
using AnnouncementService.Shared.DTOs;

namespace AnnouncementService.DAL.Interfaces
{
    public interface IAnnouncementRepository
    {
        //queries
        public Task<Announcement> GetAnnouncementByIdAsync(Guid id);
        public Task<IEnumerable<Announcement>> GetAnnouncementsByCreatorIdAsync(string creatorId);
        public Task<IEnumerable<Announcement>> GetAnnouncementsByTitleAsync(string title);
        public Task<IEnumerable<Announcement>> GetAnnouncementsAsync();
        public Task<IEnumerable<AnnouncementPreviewDto>> GetAnnouncementsPreviewAsync();
        //commands
        public Task CreateAnnouncementAsync(Announcement announcement); 
        public Task UpdateAnnouncementAsync(Announcement announcement); 
        public Task DeleteAnnouncementAsync(Guid id);
    }
}
