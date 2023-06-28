using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Infrastructure.Data;

namespace TaskManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddApplicationDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString, b => b.MigrationsAssembly("TaskManagement.Infrastructure")));
        }
    }
}
