using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JourneyNavigation.Domain.Interfaces;
using JourneyNavigation.Infrastructure.Data;
using JourneyNavigation.Infrastructure.Repositories;

namespace JourneyNavigation.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        ApplicationDbContext _context;
        IJourneyRepository _journeyRepository;
        IUsersRepository _userRepository;
        ITransportationTypeRepository _transportationTypeRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public ApplicationDbContext GetDbContext()
        {
            return _context;
        }
        public async Task SaveChangesAsync()
        {
             await _context.SaveChangesAsync();
        }

        public IJourneyRepository Journeys
        {
            get
            {
                if (_journeyRepository == null)
                    _journeyRepository = new JourneyRepository(_context);

                return _journeyRepository;
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

        public ITransportationTypeRepository TransportationType
        {
            get
            {
                if (_transportationTypeRepository == null)
                    _transportationTypeRepository = new TransportationTypeRepository(_context);

                return _transportationTypeRepository;
            }
        }
    }
}
