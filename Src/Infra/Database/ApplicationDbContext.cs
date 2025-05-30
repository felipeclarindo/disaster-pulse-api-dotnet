using DisasterPulseApiDotnet.Src.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisasterPulseApiDotnet.Src.Infra.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Warn> Warns { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Alert>().HasOne<Country>();

            modelBuilder.Entity<Country>().HasMany<Alert>();
            modelBuilder.Entity<Country>().HasMany<Warn>();
            modelBuilder.Entity<Warn>();
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
        }
    }
}
