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
        public IActionResult GetTaskById(int id)
        {
            var result = _taskService.GetTaskById(id);
            return Ok(result);
        }
    }
}
