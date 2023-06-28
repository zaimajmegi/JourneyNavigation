using TaskManagement.API.Dtos;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure;
using TaskManagement.API.Extensions;

namespace TaskManagement.API.Services
{
    public class TaskService : ITaskService
    {
        private IUnitOfWork _unitOfWork;

        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TaskDto> GetTaskById(int taskId)
        {
            var task = await _unitOfWork.Tasks.GetAsync(taskId);
            if (task == null)
                throw new Exception("Task not found");

            var taskDto = TaskDto.FromEntity(task);
            return taskDto;
        }
    }
}
