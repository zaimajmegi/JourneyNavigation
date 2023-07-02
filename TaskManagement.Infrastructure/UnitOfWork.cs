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
        IUsersRepository _userRepository;
        IProjectsRepository _projectRepository;
        IPriorityRepository _priorityRepository;

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

        public IUsersRepository Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context);

                return _userRepository;
            }
        }

        public IProjectsRepository Projects
        {
            get
            {
                if (_projectRepository == null)
                    _projectRepository = new ProjectRepository(_context);

                return _projectRepository;
            }
        }

        public IPriorityRepository Priorities
        {
            get
            {
                if (_priorityRepository == null)
                    _priorityRepository = new PriorityRepository(_context);

                return _priorityRepository;
            }
        }
    }
}
