namespace TestJob.DAL.Repositories
{
    public class DataProjectRepository : IProjectRepository
    {
        private readonly DataContext _db;

        public DataProjectRepository(DataContext db)
        {
            _db = db;
        }

        public async Task Create(IProject obj)
        {
            var project = new ProjectEntity(obj);
            await _db.Projects.AddAsync(project);
        }

        public Task Delete(Guid id)
        {
            _db.Projects.Remove(new ProjectEntity() { Id = id });
            return Task.CompletedTask;
        }

        public IEnumerable<IProject> GetAll()
        {
            return _db.Projects;
        }
    }
}
