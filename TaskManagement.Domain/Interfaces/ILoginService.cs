using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.API.Dtos;
using TaskManagement.Domain.Models;

namespace TaskManagement.Domain.Interfaces
{
    public interface ILoginService
    {
        string Generate(User user);
        Task<User> Authenticate(UserDto userLogin);
    }
}
