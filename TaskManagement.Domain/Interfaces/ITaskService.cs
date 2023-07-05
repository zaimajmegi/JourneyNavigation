using TaskManagement.API.Dtos;

namespace TaskManagement.Domain.Interfaces
{
    public interface ITaskService
    {
        Task<TaskDto> AddTask(TaskDto task);
        Task<TaskDto> UpdateTask(TaskDto updatedTask);
        Task<TaskDto> DeleteTask(int taskId);
        Task<TaskDto> GetTaskById(int taskId);
        Task<TaskDto> AssignTaskUser(int taskId, string userId);
        Task<TaskDto> SetTaskDueDate(int taskId, DateTime dueDate);
        Task<TaskDto> AddTaskDescription(int taskId, string taskDesc);
        Task<int> TrackTask(int taskId);
        Task<List<TaskDto>> GetProjectTasks(int projectId);
        Task<List<TaskDto>> FilterByPriority(int priorityId);
    }
}
