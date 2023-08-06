using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using System.Security;
using JourneyNavigation.Domain.Models;

namespace JourneyNavigation.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, UserRole, string>
    {
        public string? CurrentUserId { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<TransportationType> TransportationTypes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TransportationType>().HasData(
                new TransportationType { Id = 1, Transportation = "Car" },
                new TransportationType { Id = 2, Transportation = "Airplane" },
                new TransportationType { Id = 3, Transportation = "Bus" }
                );

        }
    }
}
