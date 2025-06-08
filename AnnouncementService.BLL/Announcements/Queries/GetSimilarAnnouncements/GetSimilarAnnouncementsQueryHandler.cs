using AnnouncementService.Core.Models;
using AnnouncementService.DAL.Interfaces;
using MediatR;

namespace AnnouncementService.BLL.Announcements.Queries.GetSimilarAnnouncements
{
    public class GetSimilarAnnouncementsQueryHandler : IRequestHandler<GetSimilarAnnouncementsQuery, IEnumerable<Announcement>>
    {
        private readonly IAnnouncementRepository _announcementRepository;
        public GetSimilarAnnouncementsQueryHandler(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }
        public async Task<IEnumerable<Announcement>> Handle(GetSimilarAnnouncementsQuery request, CancellationToken cancellationToken)
        {
            Announcement example = await _announcementRepository.GetAnnouncementByIdAsync(request.ExapmleId);
            var candidates = await _announcementRepository.GetAnnouncementsAsync();
            var similarAnnouncements = candidates
                .Where(c => c.Id != example.Id && IsSimilar(c, example))
                .OrderByDescending(c => c.DateAdded)
                .Take(request.Count)
                .ToList();
            return similarAnnouncements;
        }
        private bool IsSimilar(Announcement candidate, Announcement example)
        {
            string exampleTitle = example.Title.ToLower();
            string candidateTitle = candidate.Title.ToLower();
            if (exampleTitle == candidateTitle)
                return true;

            string exampleDescription = example.Description.ToLower();
            string candidateDescription = candidate.Description.ToLower();

            string[] exampleTitleWords = exampleTitle.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] candidateTitleWords = candidateTitle.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] exampleDescriptionWords = exampleDescription.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] candidateDescriptionWords = candidateDescription.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var exampleWords = exampleTitleWords.Concat(exampleDescriptionWords).Distinct();
            var candidateWords = candidateTitleWords.Concat(candidateDescriptionWords).Distinct();

            int commonWordsCount = candidateTitleWords.Intersect(candidateDescriptionWords).Count();

            if (commonWordsCount >= 1)
                return true;
            else
                return false;
        }
    }
}
