namespace TestJob.DAL.Repositories
{
    public interface ITaskRepository : IRepository<ITask>
    {
        public Task<ITask> GetById(Guid id);
        public Task Update(Guid id, ITask obj);
        public IEnumerable<ITask> GetAllFiltered(string project, string date);
    }
}
