namespace TestJob.UI.Models
{
    public class TaskViewModel : ITask
    {
        public TaskViewModel(TaskDto task)
        {
            Id = task.Id;
            TaskName = task.TaskName;
            StartDate = task.StartDate;
            CancelDate = task.CancelDate;
            CreateDate = task.CreateDate;
            UpdateDate = task.UpdateDate;
            Project = task.Project;
            TaskComments = task.TaskComments;
            SpendTime = CancelDate - StartDate;
        }

        public Guid Id { get; set; }
        public TimeSpan SpendTime { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CancelDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public IProject Project { get; set; }
        public IEnumerable<ITaskComment> TaskComments { get; set; }

        public string SpendTimeToString()
        {
            var hours = new StringBuilder(((SpendTime.Days * 24) + SpendTime.Hours).ToString());
            var minutes = new StringBuilder(SpendTime.Minutes.ToString());
            if (hours.Length == 1)
                hours.Insert(0, '0');
            if (minutes.Length == 1)
                minutes.Insert(0, '0');
            return $"{hours}:{minutes}";
        } 
    }
}
