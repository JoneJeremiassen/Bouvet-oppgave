using Bouvet_oppgave.Models;
using Microsoft.EntityFrameworkCore;

namespace Bouvet_oppgave.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Epic> Epics { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
    }
}