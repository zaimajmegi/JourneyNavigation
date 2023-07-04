using TaskManagement.API.Extensions;
using TaskManagement.Domain.Models;

namespace TaskManagement.API.Dtos
{
    public class TaskPriorityDto : BaseDto<TaskPriorityDto, TaskPriority>
    {
        public string PriorityDesc { get; set; } = string.Empty;
    }
}
