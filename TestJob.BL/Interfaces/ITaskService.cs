using TestJob.BL.Filter;

namespace TestJob.BL.Interfaces
{
    public interface ITaskService
    {
        public Task Update(Guid id, TaskDto task);
        public Task Create(TaskDto task);
        public IEnumerable<TaskDto> GetAll();
        public IEnumerable<TaskDto> GetAllFiltered(TaskFilter filter);

        public Task<TaskDto> GetById(Guid id);
    }
}
