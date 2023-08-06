using JourneyNavigation.API.Extensions;
using JourneyNavigation.Domain.Models;

namespace JourneyNavigation.Domain.Dtos
{
    public class UserDto : BaseDto<UserDto, User>
    {
        public string? UserName { get; set; }
        public virtual string? Password { get; set; }

    }
}
