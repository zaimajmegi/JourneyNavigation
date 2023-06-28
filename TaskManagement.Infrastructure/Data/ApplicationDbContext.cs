using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Models;

namespace TaskManagement.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, UserRole, string>
    {
        public string? CurrentUserId { get; set; }
        public DbSet<TaskDB> Tasks { get; set; }
        public DbSet<TaskPriority> Priorities { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<UserProjects> UserProjectsList { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                          
    }


    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, ProjectName = "Education" },
                new Project { Id = 2, ProjectName = "Transport" },
                new Project { Id = 3, ProjectName = "Social Media" }
                );

            modelBuilder.Entity<TaskPriority>().HasData(
                new TaskPriority { Id = 1, PriorityDesc = "High" },
                new TaskPriority { Id = 2, PriorityDesc = "Medium" },
                new TaskPriority { Id = 3, PriorityDesc = "Low" }
                );
        }
    }
}
