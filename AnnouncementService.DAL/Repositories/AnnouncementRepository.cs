using AnnouncementService.Core.Models;
using AnnouncementService.DAL.Interfaces;
using AnnouncementService.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AnnouncementService.DAL.Repositories
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly AppDbContext _dbContext;
        public AnnouncementRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAnnouncementAsync(Announcement announcement)
        {
            await _dbContext.Announcements.AddAsync(announcement);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAnnouncementAsync(Guid id)
        {
           _dbContext.Announcements.Remove(await GetAnnouncementByIdAsync(id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Announcement> GetAnnouncementByIdAsync(Guid id)
        {
            return await _dbContext.Announcements.FindAsync(id) ?? 
                throw new KeyNotFoundException($"Announcement with ID {id} is not found.");
        }

        public async Task<IEnumerable<Announcement>> GetAnnouncementsAsync()
        {
            return await _dbContext.Announcements.ToListAsync();
        }

        public async Task<IEnumerable<Announcement>> GetAnnouncementsByCreatorIdAsync(string creatorId)
        {
            return await _dbContext.Announcements
                .Where(a => a.CreatorId == creatorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Announcement>> GetAnnouncementsByTitleAsync(string title)
        {
            return await _dbContext.Announcements
                .Where(a => a.Title == title)
                .ToListAsync();
        }
        public async Task<IEnumerable<AnnouncementPreviewDto>> GetAnnouncementsPreviewAsync()
        {
            IQueryable<AnnouncementPreviewDto> query = _dbContext.Announcements
                .Select(a => new AnnouncementPreviewDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                });
            return await query.ToListAsync();
        }

        public async Task UpdateAnnouncementAsync(Announcement announcement)
        {
            _dbContext.Announcements.Update(announcement);
            await _dbContext.SaveChangesAsync();

        }
    }
}
