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
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Alert>().HasKey(a => a.Id);
            modelBuilder.Entity<Alert>().Property(a => a.Criticality).HasConversion<string>();
            modelBuilder.Entity<Alert>()
                .HasOne(a => a.Country)
                .WithMany(c => c.Alerts)
                .HasForeignKey(a => a.CountryId);

            modelBuilder.Entity<Country>()
                .HasMany(c => c.Alerts)
                .WithOne(a => a.Country)
                .HasForeignKey(a => a.CountryId);

            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Role).HasConversion<string>();
        }
    }
}