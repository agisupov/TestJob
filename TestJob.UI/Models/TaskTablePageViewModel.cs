namespace TestJob.UI.Models
{
    public class TaskTablePageViewModel
    {
        public TaskTablePageViewModel(IEnumerable<TaskDto> tasks, IEnumerable<ProjectDto> projects)
        {
            Tasks = tasks.Select(x => new TaskViewModel(x));
            Projects = projects.Select(x => new ProjectViewModel(x));
            foreach (var task in Tasks)
            {
                SpendTime += task.SpendTime;
            }
        }

        public TimeSpan SpendTime { get; set; }
        public IEnumerable<TaskViewModel> Tasks { get; set; }
        public IEnumerable<ProjectViewModel> Projects { get; set; }
    }
}
