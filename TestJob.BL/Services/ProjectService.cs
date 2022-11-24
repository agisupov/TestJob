namespace TestJob.BL.Services
{
    public class ProjectService : IProjectService
    {
        IRepositoryCollection _db;

        public ProjectService(IRepositoryCollection db)
        {
            _db = db;
        }

        public IEnumerable<ProjectDto> GetAll()
        {
            var list = _db.ProjectRepository.GetAll();
            return list.ToProjectDtoIEnumerable();
        }
    }
}
