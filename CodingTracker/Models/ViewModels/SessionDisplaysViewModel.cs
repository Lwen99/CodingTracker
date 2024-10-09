using CodingTracker.Models.DomainModels;

namespace CodingTracker.Models.ViewModels
{
    public class SessionDisplaysViewModel
    {
        public List<CodingSession> CodingSessions {  get; set; }
        public List<ProjectSession> ProjectSessions { get; set; }

        public List<ReviewSession> ReviewSessions { get; set; }
    }
}
