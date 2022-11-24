namespace TestJob.DAL.Repositories
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();
        public Task Create(T obj);
        public Task Delete(Guid id);
    }
}
