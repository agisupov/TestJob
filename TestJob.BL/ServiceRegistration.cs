using Microsoft.Extensions.DependencyInjection;

namespace TestJob.BL
{
    public static class ServiceRegistration
    {
        public static void RegisterServicesForTasksAndComments(this IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITaskCommentService, TaskCommentService>();

            services.AddScoped<ServiceManager>();

            services.AddDbContext<DataContext>();
            services.AddScoped<IRepositoryCollection, RepositoryCollection>();
        }
    }
}
