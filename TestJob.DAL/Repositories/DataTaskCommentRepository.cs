namespace TestJob.DAL.Repositories
{
    internal class DataTaskCommentRepository : ITaskCommentRepository
    {
        private readonly DataContext _db;

        public DataTaskCommentRepository(DataContext db)
        {
            _db = db;
        }

        public async Task Create(ITaskComment obj)
        {
            var taskComment = new TaskCommentEntity(obj);
            await _db.TaskComments.AddAsync(taskComment);
        }

        public Task Delete(Guid id)
        {
            _db.TaskComments.Remove(new TaskCommentEntity { Id = id });
            return Task.CompletedTask;
        }

        public IEnumerable<ITaskComment> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
