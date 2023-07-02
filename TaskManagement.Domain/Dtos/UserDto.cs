using TaskManagement.API.Extensions;
using TaskManagement.Domain.Models;

namespace TaskManagement.API.Dtos
{
    public class UserDto : BaseDto<UserDto, User>
    {
        public string? UserName { get; set; }
        public virtual string? PasswordHash { get; set; }

    }
}
