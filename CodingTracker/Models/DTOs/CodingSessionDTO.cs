using CodingTracker.Models.DomainModels;

namespace CodingTracker.Models.DTOs
{
    public class CodingSessionDTO : Sessions
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
    }
}
