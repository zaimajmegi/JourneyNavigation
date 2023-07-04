using TaskManagement.API.Extensions;
using TaskManagement.Domain.Models;

namespace TaskManagement.API.Dtos
{
    public class ProjectDto : BaseDto<ProjectDto, Project>
    {
        public string ProjectName { get; set; } = string.Empty;
    }
}
