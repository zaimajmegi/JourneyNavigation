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

        public TaskDto AddTask(TaskDto task)
        {
            var taskDb = task.ToEntity();

            _unitOfWork.Tasks.Add(taskDb);

            return task;
        }

        public async Task<TaskDto> UpdateTask(int taskId, TaskDto updatedTask)
        {
            var task = await _unitOfWork.Tasks.GetAsync(taskId);
            if (task == null)
                throw new Exception("Task not found");

            var taskNew = updatedTask.ToEntity();
            task = taskNew;

            _unitOfWork.Tasks.Update(task);

            return updatedTask;
        }

        public async Task<TaskDto> DeleteTask(int taskId)
        {
            var task = await _unitOfWork.Tasks.GetAsync(taskId);
            if (task == null)
                throw new Exception("Task not found");

            _unitOfWork.Tasks.Remove(task);

            var taskDto = TaskDto.FromEntity(task);
            return taskDto;
        }

        public async Task<TaskDto> GetTaskById(int taskId)
        {
            var task = await _unitOfWork.Tasks.GetAsync(taskId);
            if (task == null)
                throw new Exception("Task not found");

            var taskDto = TaskDto.FromEntity(task);
            return taskDto;
        }

        public async Task<TaskDto> AssignTaskUser(int taskId, int userId)
        {
            var task = await _unitOfWork.Tasks.GetAsync(taskId);
            if (task == null)
                throw new Exception("Task not found");

            var user = await _unitOfWork.Users.GetAsync(userId);
            if (user == null)
                throw new Exception("User not found");

            task.AssignedTo = user;
            _unitOfWork.Tasks.Update(task);

            var taskDto = TaskDto.FromEntity(task);
            return taskDto;
        }

        public async Task<TaskDto> SetTaskDueDate(int taskId, DateTime dueDate)
        {
            var task = await _unitOfWork.Tasks.GetAsync(taskId);
            if (task == null)
                throw new Exception("Task not found");

            if (dueDate <= DateTime.Now)
                throw new Exception("Due date needs to be longer");

            task.DueDate = dueDate;
            _unitOfWork.Tasks.Update(task);

            var taskDto = TaskDto.FromEntity(task);
            return taskDto;
        }

        public async Task<TaskDto> AddTaskDescription(int taskId, string taskDesc)
        {
            var task = await _unitOfWork.Tasks.GetAsync(taskId);
            if (task == null)
                throw new Exception("Task not found");

            task.TaskDesc = taskDesc;
            _unitOfWork.Tasks.Update(task);

            var taskDto = TaskDto.FromEntity(task);
            return taskDto;
        }

        public async Task<int> TrackTask(int taskId)
        {
            var task = await _unitOfWork.Tasks.GetAsync(taskId);
            if (task == null)
                throw new Exception("Task not found");

            return task.TaskStatus;
        }

        public async Task<List<TaskDto>> GetProjectTasks(int projectId)
        {
            var project = await _unitOfWork.Projects.GetAsync(projectId);
            if (project == null)
                throw new Exception("Project not found");

            var tasks = _unitOfWork.Tasks.GetProjectTasks(project);
            if (tasks == null)
                throw new Exception("Tasks not found");

            var tasksDto = TaskDto.FromEntityList(tasks);
            return tasksDto;
        }

        public async Task<List<TaskDto>> FilterByPriority(int priorityId)
        {
            var priority = await _unitOfWork.Priorities.GetAsync(priorityId);
            if (priority == null)
                throw new Exception("Priority type not found");

            var tasks = _unitOfWork.Tasks.FilterByPriority(priority);
            if (tasks == null)
                throw new Exception("Tasks not found");

            var tasksDto = TaskDto.FromEntityList(tasks);
            return tasksDto;
        }
    }
}
