namespace TestJob.BL.Models
{
    public class TaskCommentDto : ITaskComment
    {
        public Guid Id { get; set; }
        public ITask Task { get; set; }
        public byte CommentType { get; set; }
        public byte[] Content { get; set; }
    }
}
