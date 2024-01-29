using FindCarrier.Domain.Entities;
using FindCarrier.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace FindCarrier.Domain
{
    public class CarrierDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<University> University { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }
        public virtual DbSet<Resume> Resume { get; set; }
        public virtual DbSet<UniversityApplication> UniversityApplication { get; set; }
        public virtual DbSet<Company> Companies { get; set; }   
        public virtual DbSet<JobType> JobTypes { get; set; }   
        public CarrierDbContext(DbContextOptions<CarrierDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new JobTypeDataSeeding());
        }
    }
}
