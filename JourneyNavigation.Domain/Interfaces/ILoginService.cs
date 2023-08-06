using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JourneyNavigation.Domain.Dtos;
using JourneyNavigation.Domain.Models;

namespace JourneyNavigation.Domain.Interfaces
{
    public interface ILoginService
    {
        string Generate(User user, bool isAdmin);
        Task<User> Authenticate(UserDto userLogin);
    }
}
