namespace TestJob.DAL.Infrastructure
{
    public interface IRepositoryCollection : IAsyncDisposable
    {
        public IProjectRepository ProjectRepository { get; }
        public ITaskRepository TaskRepository { get; }
        public ITaskCommentRepository TaskCommentRepository { get; }
        public Task Save();
    }
}
