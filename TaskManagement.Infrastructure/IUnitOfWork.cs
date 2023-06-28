using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Data;

namespace TaskManagement.Infrastructure
{
    public interface IUnitOfWork
    {
        public ApplicationDbContext GetDbContext();
        ITaskRepository Tasks { get; }
    }
}
