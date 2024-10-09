using CodingTracker.HelpMethods;
using CodingTracker.Models.DomainModels;
using CodingTracker.Models.DTOs;
using CodingTracker.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodingTracker.Controllers
{
    public class SessionsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public SessionsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<CodingSession> codingSessions = _context.CodingSessions.ToList();
            List<ProjectSession> projectSessions = _context.ProjectSessions.ToList();
            List<ReviewSession> reviewSessions = _context.ReviewsSessions.ToList();
            SessionDisplaysViewModel viewModel = new SessionDisplaysViewModel
            {
                CodingSessions = codingSessions,
                ProjectSessions = projectSessions,
                ReviewSessions = reviewSessions
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            SessionTypesViewModel model = new SessionTypesViewModel();
            model.SelectSessionTypesList = new List<SelectListItem>
            {
                new SelectListItem{Text = "Select a session", Value="", Selected=true }
            };

            

            model.SelectSessionTypesList.AddRange(Enum.GetValues(typeof(SessionTypes))
                                                .Cast<SessionTypes>()
                                                .Select(r => new SelectListItem
                                                {
                                                    Text = r.GetDisplayName(),
                                                    Value = ((int)r).ToString()
                                                }).ToList());

            return View(model);
        }

        public IActionResult LoadSessionPartial(int sessionId)
        {
            switch (sessionId)
            {
                case 0:
                    CodingSessionDTO codingSession = new CodingSessionDTO();
                    return PartialView("SessionForms/_CodingSessionForm", codingSession);
                case 1:
                    ReviewSessionDTO reviewSession = new ReviewSessionDTO();
                    return PartialView("SessionForms/_ReviewSessionForm", reviewSession);
                case 2:
                    ProjectSessionDTO projectSession = new ProjectSessionDTO();
                    return PartialView("SessionForms/_ProjectSessionForm", projectSession);
                default:
                    return View();
            }

        }
    }
}
