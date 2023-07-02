using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService )
        {
            _taskService = taskService;
        }

        [HttpGet(nameof(GetTaskById))]
        [Authorize]
        public IActionResult GetTaskById(int taskId)
        {
            var result = _taskService.GetTaskById(taskId);
            return Ok(result);
        }

        [HttpPost(nameof(AssignTaskUser))]
        [Authorize]
        public IActionResult AssignTaskUser(int taskId, int userId)
        {
            var result = _taskService.AssignTaskUser(taskId, userId);
            return Ok(result);
        }

        [HttpPost(nameof(SetTaskDueDate))]
        [Authorize]
        public IActionResult SetTaskDueDate(int taskId, DateTime dueDate)
        {
            var result = _taskService.SetTaskDueDate(taskId, dueDate);
            return Ok(result);
        }

        [HttpPost(nameof(AddTaskDescription))]
        [Authorize]
        public IActionResult AddTaskDescription(int taskId, string desc)
        {
            var result = _taskService.AddTaskDescription(taskId, desc);
            return Ok(result);
        }

        [HttpGet(nameof(TrackTask))]
        [Authorize]
        public IActionResult TrackTask(int taskId)
        {
            var result = _taskService.TrackTask(taskId);
            return Ok(result);
        }

        [HttpGet(nameof(GetProjectTasks))]
        [Authorize]
        public IActionResult GetProjectTasks(int projectId)
        {
            var result = _taskService.GetProjectTasks(projectId);
            return Ok(result);
        }

        [HttpGet(nameof(FilterByPriority))]
        [Authorize]
        public IActionResult FilterByPriority(int priorityId)
        {
            var result = _taskService.FilterByPriority(priorityId);
            return Ok(result);
        }
    }
}
