using TaskManagement.Infrastructure.Data;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Domain.Models;

namespace TaskManagement.Infrastructure.Repositories
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
