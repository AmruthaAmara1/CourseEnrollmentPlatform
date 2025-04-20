using System.Data.Entity;

namespace CourseEnrollmentPlatform.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Course> Courses { get; set; }
    }
}