namespace TestJob.UI.Models
{
    public class CreateTaskCommentViewModel
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public byte CommentType { get; set; }
        public string Content { get; set; }

        public TaskCommentDto AsCommentDto()
        {
            return new TaskCommentDto()
            {
                Id = Id,
                Task = new TaskDto() { Id = TaskId },
                CommentType = CommentType,
                Content = Encoding.UTF8.GetBytes(Content)
            };
        }
    }
}
