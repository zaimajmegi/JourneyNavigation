using TaskManagement.Infrastructure.Data;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Domain.Models;

namespace TaskManagement.Infrastructure.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectsRepository
    {

        private readonly ApplicationDbContext _appContext;

        public ProjectRepository(ApplicationDbContext context) : base(context)
        {
            _appContext = context;
        }


    }
}
