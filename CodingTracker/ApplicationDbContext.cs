using CodingTracker.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace CodingTracker
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        public DbSet<CodingSession> CodingSessions { get; set; }

        public DbSet<ProjectSession> ProjectSessions { get; set; }

        public DbSet<ReviewSession> ReviewsSessions { get; set; }
    }
}
