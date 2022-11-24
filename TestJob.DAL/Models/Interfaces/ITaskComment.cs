namespace TestJob.DAL.Models
{
    public interface ITaskComment
    {
        public Guid Id { get; set; }
        public ITask Task { get; set; }
        public byte CommentType { get; set; }
        public byte[] Content { get; set; }
    }
}
