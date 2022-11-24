namespace TestJob.BL.Interfaces
{
    public interface ITaskCommentService
    {
        public IEnumerable<TaskCommentDto> GetAll();
        public Task Create(TaskCommentDto taskComment);
        public Task Delete(Guid id);
    }
}
