using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Data;
using TaskManagement.Infrastructure.Repositories;

namespace TaskManagement.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        ApplicationDbContext _context;
        ITaskRepository _taskRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public ApplicationDbContext GetDbContext()
        {
            return _context;
        }

        public ITaskRepository Tasks
        {
            get
            {
                if (_taskRepository == null)
                    _taskRepository = new TaskRepository(_context);

                return _taskRepository;
            }
        }
    }
}
