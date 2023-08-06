using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using JourneyNavigation.Infrastructure.Data;

namespace JourneyNavigation.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddApplicationDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString, b => b.MigrationsAssembly("JourneyNavigation.Infrastructure")));
        }
    }
}
