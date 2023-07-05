using System.ComponentModel.DataAnnotations;
using TaskManagement.API.Extensions;
using TaskManagement.Domain.Models;

namespace TaskManagement.API.Dtos
{
    public class TaskDto : BaseDto<TaskDto, TaskDB>
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string TaskName { get; set; } = string.Empty;
        [MaxLength(500)]
        public string TaskDesc { get; set; } = string.Empty;
        public string? CreatedById { get; set; }
        public string? AssignedToId { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }
        [Range(0, 100, ErrorMessage = "Task staus should be between 0 and 100%")]
        public int TaskStatus { get; set; }
        public int? ProjectId { get; set; }
        public int? TaskPriorityId { get; set; }
    }
}
