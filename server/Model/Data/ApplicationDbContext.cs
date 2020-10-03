using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using server.Extensions;

namespace server.Model.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        private readonly IPasswordHasher<User> _hasher;

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employer> Employees { get; set; }

        public ApplicationDbContext(DbContextOptions options, IPasswordHasher<User> hasher)
            : base(options)
        {
            _hasher = hasher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>()
                .ToTable("Companies");

            modelBuilder.Entity<Employer>()
                .ToTable("Employers");

            modelBuilder.Entity<Employer>()
                .Property(emp => emp.JobTitle)
                .HasConversion<string>();

            modelBuilder.Seed(_hasher);
        }
    }
}
