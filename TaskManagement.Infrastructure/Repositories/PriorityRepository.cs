using TaskManagement.Infrastructure.Data;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Domain.Models;

namespace TaskManagement.Infrastructure.Repositories
{
    public class PriorityRepository : Repository<TaskPriority>, IPriorityRepository
    {

        private readonly ApplicationDbContext _appContext;

        public PriorityRepository(ApplicationDbContext context) : base(context)
        {
            _appContext = context;
        }


    }
}
