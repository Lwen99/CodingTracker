using CodingTracker.Models.DomainModels;
using CodingTracker.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CodingTracker.Controllers
{
    public class ProjectSessionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectSessionController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("ProjectSession/Index/{id}")]

        public IActionResult Index([FromRoute] int id)
        {
            ProjectSession projectSession = _context.ProjectSessions.FirstOrDefault(x => x.Id == id);
            return View(projectSession);
        }

        [HttpPost]

        public IActionResult Create(ProjectSessionDTO model)
        {
            if (ModelState.IsValid) 
            {
                ProjectSession projectSession = new ProjectSession
                {
                    Description = model.Description,
                    Name = model.Name,
                    Duration = new TimeSpan(model.Hours, model.Minutes, 0),
                    CreatedDate = model.CreatedDate,
                };

                _context.ProjectSessions.Add(projectSession);
                _context.SaveChanges();
                return RedirectToAction("Index", "Sessions");

            }
            return View(model);

        }
    }
}
