using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.API.Dtos;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService )
        {
            _taskService = taskService;
        }

        [HttpPost(nameof(AddTask))]
        public async Task<IActionResult> AddTask([FromBody]TaskDto task)
        {
            var result = await _taskService.AddTask(task);
            return Ok(result);
        }

        [HttpPut(nameof(UpdateTask))]
        public async Task<IActionResult> UpdateTask(TaskDto updatedTask)
        {
            var result = await _taskService.UpdateTask(updatedTask);
            return Ok(result);
        }

        [HttpDelete(nameof(DeleteTask))]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            var result = await _taskService.DeleteTask(taskId);
            return Ok(result);
        }

        [HttpGet(nameof(GetTaskById))]
        public async Task<IActionResult> GetTaskById(int taskId)
        {
            var result = await _taskService.GetTaskById(taskId);
            return Ok(result);
        }

        [HttpPut(nameof(AssignTaskUser))]
        public async Task<IActionResult> AssignTaskUser(int taskId, string userId)
        {
            var result = await _taskService.AssignTaskUser(taskId, userId);
            return Ok(result);
        }

        [HttpPut(nameof(SetTaskDueDate))]
        
        public async Task<IActionResult> SetTaskDueDate(int taskId, DateTime dueDate)
        {
            var result = await _taskService.SetTaskDueDate(taskId, dueDate);
            return Ok(result);
        }

        [HttpPut(nameof(AddTaskDescription))]
        
        public async Task<IActionResult> AddTaskDescription(int taskId, string desc)
        {
            var result = await _taskService.AddTaskDescription(taskId, desc);
            return Ok(result);
        }

        [HttpGet(nameof(TrackTask))]
        
        public async Task<IActionResult> TrackTask(int taskId)
        {
            var result = await  _taskService.TrackTask(taskId);
            return Ok(result);
        }

        [HttpGet(nameof(GetProjectTasks))]
        
        public async Task<IActionResult> GetProjectTasks(int projectId)
        {
            var result = await _taskService.GetProjectTasks(projectId);
            return Ok(result);
        }

        [HttpGet(nameof(FilterByPriority))]
        
        public async Task<IActionResult> FilterByPriority(int priorityId)
        {
            var result = await _taskService.FilterByPriority(priorityId);
            return Ok(result);
        }
    }
}
