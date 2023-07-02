using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Models
{
    public class TaskDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string TaskName { get; set; } = string.Empty;
        [MaxLength(500)]
        public string TaskDesc { get; set; } = string.Empty;
        public User? CreatedBy { get; set; }
        public User? AssignedTo { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }
        public int TaskStatus { get; set; }
        public Project? Project { get; set; }
        public TaskPriority? TaskPriority { get; set; }
    }
}
