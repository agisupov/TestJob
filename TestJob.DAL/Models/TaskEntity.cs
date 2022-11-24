namespace TestJob.DAL.Models
{
    public class TaskEntity : ITask
    {
        public TaskEntity()
        {

        }

        public TaskEntity(ITask task)
        {
            Id = task.Id;
            TaskName = task.TaskName;
            StartDate = task.StartDate;
            CancelDate = task.CancelDate;
            CreateDate = StartDate;
            UpdateDate = StartDate;
            ProjectId = task.Project.Id;
        }

        public Guid Id { get; set; }
        [MaxLength(255)]
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CancelDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Guid ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public ProjectEntity ProjectModel { get; set; }

        public IEnumerable<TaskCommentEntity> TaskComments { get; set; }

        [NotMapped]
        public IProject Project
        {
            get => ProjectModel;
            set => ProjectModel = new ProjectEntity(value);
        }
        IEnumerable<ITaskComment> ITask.TaskComments
        {
            get => TaskComments;
            set => TaskComments = value as IEnumerable<TaskCommentEntity>;
        }
    }
}
