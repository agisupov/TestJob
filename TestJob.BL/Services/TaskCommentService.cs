namespace TestJob.BL.Services
{
    public class TaskCommentService : ITaskCommentService
    {
        private readonly IRepositoryCollection _db;

        public TaskCommentService(IRepositoryCollection db)
        {
            _db = db;
        }

        public async Task Create(TaskCommentDto taskComment)
        {
            await _db.TaskCommentRepository.Create(taskComment);
        }

        public async Task Delete(Guid id)
        {
            await _db.TaskCommentRepository.Delete(id);
        }

        public IEnumerable<TaskCommentDto> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
