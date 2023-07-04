using System.ComponentModel.DataAnnotations;
using TaskManagement.API.Extensions;
using TaskManagement.Domain.Models;

namespace TaskManagement.API.Dtos
{
    public class TaskDto : BaseDto<TaskDto, TaskDB>
    {
        public int Id { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public string TaskDesc { get; set; } = string.Empty;
        public string? CreatedById { get; set; }
        public string? AssignedToId { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }
        public int TaskStatus { get; set; }
        public int? ProjectId { get; set; }
        public int? TaskPriorityId { get; set; }
    }
}
