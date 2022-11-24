namespace TestJob.BL.Models
{
    public class TaskDto : ITask
    {
        public TaskDto()
        {

        }

        public TaskDto(ITask task)
        {
            Id = task.Id;
            TaskName = task.TaskName;
            StartDate = task.StartDate;
            CancelDate = task.CancelDate;
            CreateDate = task.CreateDate;
            UpdateDate = task.UpdateDate;
            Project = task.Project;
            TaskComments = task.TaskComments;
        }

        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CancelDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public IProject Project { get; set; }
        public IEnumerable<ITaskComment> TaskComments { get; set; }

    }
}
