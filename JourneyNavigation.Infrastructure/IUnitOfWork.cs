using JourneyNavigation.Domain.Interfaces;
using JourneyNavigation.Infrastructure.Data;

namespace JourneyNavigation.Infrastructure
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
        ApplicationDbContext GetDbContext();
        IJourneyRepository Journeys { get; }
        IUsersRepository Users { get; }
        ITransportationTypeRepository TransportationType { get; }
    }
}
