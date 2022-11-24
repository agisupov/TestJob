namespace TestJob.DAL.Models
{
    public class TaskCommentEntity : ITaskComment
    {
        public TaskCommentEntity()
        {

        }

        public TaskCommentEntity(ITaskComment taskComment)
        {
            Id = taskComment.Id;
            TaskId = taskComment.Task.Id;
            CommentType = taskComment.CommentType;
            Content = taskComment.Content;
        }

        public Guid Id { get; set; }
        public byte CommentType { get; set; }
        public byte[] Content { get; set; }

        public Guid TaskId { get; set; }

        [ForeignKey(nameof(TaskId))]
        public TaskEntity TaskModel { get; set; }

        [NotMapped]
        ITask ITaskComment.Task { get => TaskModel; set { TaskModel = new TaskEntity(value); } }

    }
}
