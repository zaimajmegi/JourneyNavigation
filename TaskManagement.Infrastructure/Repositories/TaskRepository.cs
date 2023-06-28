using TaskManagement.Infrastructure.Data;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Domain.Models;

namespace TaskManagement.Infrastructure.Repositories
{
    public class TaskRepository : Repository<TaskDB>, ITaskRepository
    {

        private readonly ApplicationDbContext _appContext;

        public TaskRepository(ApplicationDbContext context) : base(context)
        {
            _appContext = context;
        }


    }
}
