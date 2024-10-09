using CodingTracker.Models.DomainModels;
using CodingTracker.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CodingTracker.Controllers
{
    public class ReviewSessionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewSessionController(ApplicationDbContext context)
        {
            _context = context; 
        }
        [HttpGet("ReviewSession/Index/{id}")]
        public IActionResult Index([FromRoute] int id)
        {
            ReviewSession reviewSession = _context.ReviewsSessions.FirstOrDefault(s => s.Id == id);
            return View(reviewSession);
        }
        [HttpPost]
        public IActionResult Create(ReviewSessionDTO model)
        {
            if (ModelState.IsValid)
            {
                ReviewSession reviewSession = new ReviewSession
                {
                    Description = model.Description,
                    Subject = model.Subject,
                    Duration = new TimeSpan(model.Hours, model.Minutes,0),
                    CreatedDate = DateTime.Now,
                };
                _context.ReviewsSessions.Add(reviewSession);
                _context.SaveChanges();
                return RedirectToAction("Index", "Sessions");
            }
            return View(model);
        }
    }
}
