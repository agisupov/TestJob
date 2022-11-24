namespace TestJob.UI.Models
{
    public class ProjectViewModel
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public ProjectViewModel(ProjectDto obj)
        {
            Id = obj.Id;
            ProjectName = obj.ProjectName;
        }
    }
}
