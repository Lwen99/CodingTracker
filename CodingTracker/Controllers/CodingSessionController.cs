using CodingTracker.Models.DomainModels;
using CodingTracker.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CodingTracker.Controllers
{
    public class CodingSessionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CodingSessionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("CodingSession/Index/{id}")]
        public IActionResult Index([FromRoute]int id)
        {
            CodingSession codingSession = _context.CodingSessions.FirstOrDefault(c => c.Id == id);

            return View(codingSession);
        }



        [HttpPost]
        public IActionResult Create(CodingSessionDTO model)
        {
            if (ModelState.IsValid)
            {
                TimeSpan duration = new TimeSpan(model.Hours, model.Minutes, 0);
                CodingSession codingSession = new CodingSession
                {
                    Description = model.Description,
                    Duration = duration,
                    CreatedDate = DateTime.Now,

                };
                _context.CodingSessions.Add(codingSession);
                _context.SaveChanges();
                // Save the model
                return RedirectToAction("Index", "Sessions");
            }
            return View(model);
        }

    }
}