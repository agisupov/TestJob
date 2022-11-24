namespace TestJob.UI.Models
{
    public class TaskPageViewModel
    {
        public TaskPageViewModel(TaskDto task, IEnumerable<ProjectDto> projects)
        {
            Task = new TaskViewModel(task);
            Projects = projects.Select(x => new ProjectViewModel(x));
        }

        public TaskViewModel Task { get; set; }
        public IEnumerable<ProjectViewModel> Projects { get; set; }
    }
}
