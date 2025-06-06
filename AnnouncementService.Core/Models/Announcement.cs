namespace AnnouncementService.Core.Models
{
    public class Announcement
    {
        public Guid Id { get; set; }
        public string CreatorId { get; set; } //guid as string for Identity compatibility
        public string Title { get; set; } 
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; } 
    }
}
