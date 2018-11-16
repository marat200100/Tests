using System.Data.Entity;

namespace Tests.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }
        
        public DbSet<Therapist> Therapists { get; set; }
        public DbSet<Psychiatrist> Psychiatrists { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}