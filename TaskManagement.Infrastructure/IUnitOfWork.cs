using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Data;

namespace TaskManagement.Infrastructure
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
        ApplicationDbContext GetDbContext();
        ITaskRepository Tasks { get; }
        IUsersRepository Users { get; }
        IProjectsRepository Projects { get; }
        IPriorityRepository Priorities { get; }
    }
}
