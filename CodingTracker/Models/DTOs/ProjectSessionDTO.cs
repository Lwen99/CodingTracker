using CodingTracker.Models.DomainModels;

namespace CodingTracker.Models.DTOs
{
    public class ProjectSessionDTO : Sessions
    {
        public int Hours {  get; set; }
        public int Minutes { get; set; }

        public string Name { get; set; }
    }
}
