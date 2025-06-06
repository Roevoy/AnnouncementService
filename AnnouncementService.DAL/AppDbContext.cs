using AnnouncementService.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnnouncementService.DAL
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Announcement> Announcements { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Announcement>()
                .HasKey(a => a.Id);

            builder.Entity<Announcement>()
                .HasOne<IdentityUser>()
                .WithMany()
                .HasForeignKey(announcement => announcement.CreatorId);

            builder.Entity<Announcement>()
                .HasIndex(a => a.Title);
        }
    }
}
