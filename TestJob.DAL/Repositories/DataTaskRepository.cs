namespace TestJob.DAL.Repositories
{
    public class DataTaskRepository : ITaskRepository
    {
        private readonly DataContext _db;

        public DataTaskRepository(DataContext dataContext)
        {
            _db = dataContext;
        }

        public async Task Create(ITask obj)
        {
            var task = new TaskEntity(obj);
            await _db.Tasks.AddAsync(task);
        }

        public Task Delete(Guid id)
        {
            _db.Remove(new TaskEntity() { Id = id });
            return Task.CompletedTask;
        }

        public IEnumerable<ITask> GetAll()
        {
            return _db.Tasks.Include(x => x.ProjectModel);
        }

        public IEnumerable<ITask> GetAllFiltered(string project, string date)
        {
            var tasks = _db.Tasks.Include(x => x.ProjectModel).AsQueryable();
            if (project != null)
                tasks = tasks.Where(x => x.ProjectModel.ProjectName == project);
            if (date != null)
            {
                var dateValue = DateTime.Parse(date).Date;
                tasks = tasks.Where(x => x.CancelDate.Date == dateValue || x.StartDate.Date == dateValue);
            }
            return tasks;
        }

        public async Task<ITask> GetById(Guid id)
        {
            return await _db.Tasks.Include(x => x.ProjectModel).Include(x => x.TaskComments).FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task Update(Guid id, ITask obj)
        {
            var task = new TaskEntity(obj) { Id = id };
            _db.Tasks.Update(task);
            return Task.CompletedTask;
        }
    }
}
