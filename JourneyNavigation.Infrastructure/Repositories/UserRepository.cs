using JourneyNavigation.Infrastructure.Data;
using JourneyNavigation.Domain.Interfaces;
using JourneyNavigation.Domain.Models;

namespace JourneyNavigation.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUsersRepository
    {

        private readonly ApplicationDbContext _appContext;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _appContext = context;
        }


    }
}
