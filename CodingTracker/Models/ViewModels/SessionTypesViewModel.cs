using CodingTracker.Models.DomainModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodingTracker.Models.ViewModels
{
    public class SessionTypesViewModel
    {
        public SessionTypes SessionTypes { get; set; }

        public List<SelectListItem> SelectSessionTypesList { get; set; }
    }
}
