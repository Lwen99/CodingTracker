using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodingTracker.Models.DomainModels
{
    public abstract class Sessions
    {
        public string Description {  get; set; }
        public DateTime CreatedDate { get; set; }   

        public TimeSpan Duration {  get; set; }

    }

    public enum SessionTypes
    {
        [Display(Name = "Coding Session")]
        CodingSession,

        [Display(Name = "Review Session")]

        ReviewSession,
        [Display(Name = "Project Session")]

        ProjectSession
    }
}
