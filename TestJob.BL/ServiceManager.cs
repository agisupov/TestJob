namespace TestJob.BL
{
    public class ServiceManager
    {
        private readonly DataContext _db;

        public ServiceManager(DataContext db, IProjectService projectService, ITaskCommentService taskCommentService, ITaskService taskService)
        {
            _db = db;

            ProjectService = projectService;
            TaskCommentService = taskCommentService;
            TaskService = taskService;
        }

        public IProjectService ProjectService { get; set; }
        public ITaskCommentService TaskCommentService { get; set; }
        public ITaskService TaskService { get; set; }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
