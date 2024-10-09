using CodingTracker.Models.DomainModels;

namespace CodingTracker.Models.DTOs
{
    public class ReviewSessionDTO : Sessions
    {
        public int Hours {  get; set; }
        public int Minutes { get; set; }
        public string Subject {  get; set; }

    }
}
