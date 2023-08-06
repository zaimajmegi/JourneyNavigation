using JourneyNavigation.Infrastructure.Data;
using JourneyNavigation.Domain.Interfaces;
using JourneyNavigation.Domain.Models;

namespace JourneyNavigation.Infrastructure.Repositories
{
    public class TransportationTypeRepository : Repository<TransportationType>, ITransportationTypeRepository
    {

        private readonly ApplicationDbContext _appContext;

        public TransportationTypeRepository(ApplicationDbContext context) : base(context)
        {
            _appContext = context;
        }


    }
}
