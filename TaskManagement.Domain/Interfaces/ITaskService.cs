using TaskManagement.API.Dtos;

namespace TaskManagement.Domain.Interfaces
{
    public interface ITaskService
    {
        Task<TaskDto> GetTaskById(int taskId);
    }
}
