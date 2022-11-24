namespace TestJob.DAL.Data
{
    public class DataContext : DbContext
    {
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<TaskCommentEntity> TaskComments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=AI-PT500;Database=TestJobDB;Trusted_Connection=True;TrustServerCertificate=True;"); // for my local server (SQL Server)
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestJobDB;Trusted_Connection=True;"); // for LocalDB (SQL Server)
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var projectList = new List<ProjectEntity>()
            {
                new ProjectEntity() { Id = Guid.NewGuid(), ProjectName = "Project 1", CreateDate = DateTime.Today, UpdateDate = DateTime.Now },
                new ProjectEntity() { Id = Guid.NewGuid(), ProjectName = "Project 2", CreateDate = DateTime.Today.AddDays(-1), UpdateDate = DateTime.Now.AddHours(-1) },
                new ProjectEntity() { Id = Guid.NewGuid(), ProjectName = "Project 3", CreateDate = DateTime.Today.AddDays(-2), UpdateDate = DateTime.Now.AddHours(-2) }
            };

            var taskList = new List<TaskEntity>()
            {
                new TaskEntity(){Id = Guid.NewGuid(), TaskName = "Task 1", ProjectId = projectList[0].Id, CreateDate = projectList[0].CreateDate.AddHours(1), StartDate = projectList[0].CreateDate.AddHours(2), CancelDate = projectList[0].CreateDate.AddHours(5), UpdateDate = projectList[0].CreateDate.AddHours(3) },
                new TaskEntity(){Id = Guid.NewGuid(), TaskName = "Task 2", ProjectId = projectList[2].Id, CreateDate = projectList[2].CreateDate.AddHours(1), StartDate = projectList[2].CreateDate.AddHours(2), CancelDate = projectList[2].CreateDate.AddHours(5), UpdateDate = projectList[2].CreateDate.AddHours(3) },
                new TaskEntity(){Id = Guid.NewGuid(), TaskName = "Task 3", ProjectId = projectList[1].Id, CreateDate = projectList[1].CreateDate.AddHours(1), StartDate = projectList[1].CreateDate.AddHours(2), CancelDate = projectList[1].CreateDate.AddHours(5), UpdateDate = projectList[1].CreateDate.AddHours(3) },
                new TaskEntity(){Id = Guid.NewGuid(), TaskName = "Task 4", ProjectId = projectList[0].Id, CreateDate = projectList[0].CreateDate.AddHours(1), StartDate = projectList[0].CreateDate.AddHours(2), CancelDate = projectList[0].CreateDate.AddHours(5), UpdateDate = projectList[0].CreateDate.AddHours(3) },
                new TaskEntity(){Id = Guid.NewGuid(), TaskName = "Task 5", ProjectId = projectList[1].Id, CreateDate = projectList[1].CreateDate.AddHours(1), StartDate = projectList[1].CreateDate.AddHours(2), CancelDate = projectList[1].CreateDate.AddHours(5), UpdateDate = projectList[1].CreateDate.AddHours(3) },
                new TaskEntity(){Id = Guid.NewGuid(), TaskName = "Task 6", ProjectId = projectList[1].Id, CreateDate = projectList[1].CreateDate.AddHours(1), StartDate = projectList[1].CreateDate.AddHours(2), CancelDate = projectList[1].CreateDate.AddHours(5), UpdateDate = projectList[1].CreateDate.AddHours(3) },
                new TaskEntity(){Id = Guid.NewGuid(), TaskName = "Task 7", ProjectId = projectList[2].Id, CreateDate = projectList[2].CreateDate.AddHours(1), StartDate = projectList[2].CreateDate.AddHours(2), CancelDate = projectList[2].CreateDate.AddHours(5), UpdateDate = projectList[2].CreateDate.AddHours(3) },
                new TaskEntity(){Id = Guid.NewGuid(), TaskName = "Task 8", ProjectId = projectList[0].Id, CreateDate = projectList[0].CreateDate.AddHours(1), StartDate = projectList[0].CreateDate.AddHours(2), CancelDate = projectList[0].CreateDate.AddHours(5), UpdateDate = projectList[0].CreateDate.AddHours(3) }
            };

            var taskCommentList = new List<TaskCommentEntity>()
            {
                new TaskCommentEntity(){ Id = Guid.NewGuid(), TaskId = taskList[0].Id, CommentType = 1, Content = Encoding.UTF8.GetBytes("Hello world!") },
                new TaskCommentEntity(){ Id = Guid.NewGuid(), TaskId = taskList[1].Id, CommentType = 1, Content = Encoding.UTF8.GetBytes("Add description") },
                new TaskCommentEntity(){ Id = Guid.NewGuid(), TaskId = taskList[2].Id, CommentType = 1, Content = Encoding.UTF8.GetBytes("Explore GraphQL") },
                new TaskCommentEntity(){ Id = Guid.NewGuid(), TaskId = taskList[3].Id, CommentType = 1, Content = Encoding.UTF8.GetBytes("Explore RabbitMQ") },
                new TaskCommentEntity(){ Id = Guid.NewGuid(), TaskId = taskList[4].Id, CommentType = 1, Content = Encoding.UTF8.GetBytes("Explore DI, IoC and middleware") },
                new TaskCommentEntity(){ Id = Guid.NewGuid(), TaskId = taskList[5].Id, CommentType = 1, Content = Encoding.UTF8.GetBytes("Explore Kafka") },
                new TaskCommentEntity(){ Id = Guid.NewGuid(), TaskId = taskList[6].Id, CommentType = 1, Content = Encoding.UTF8.GetBytes(".NET MAUI???") },
                new TaskCommentEntity(){ Id = Guid.NewGuid(), TaskId = taskList[7].Id, CommentType = 1, Content = Encoding.UTF8.GetBytes("DB Indexes (SQL Server)") },
                new TaskCommentEntity(){ Id = Guid.NewGuid(), TaskId = taskList[7].Id, CommentType = 1, Content = Encoding.UTF8.GetBytes("DB Indexes (PostgreSQL)") },
                new TaskCommentEntity(){ Id = Guid.NewGuid(), TaskId = taskList[7].Id, CommentType = 1, Content = Encoding.UTF8.GetBytes("DB Indexes (MySQL)") },
                new TaskCommentEntity(){ Id = Guid.NewGuid(), TaskId = taskList[0].Id, CommentType = 1, Content = Encoding.UTF8.GetBytes("Test comment") },
                new TaskCommentEntity(){ Id = Guid.NewGuid(), TaskId = taskList[6].Id, CommentType = 1, Content = Encoding.UTF8.GetBytes("ASP.NET Core 7") },
            };
            modelBuilder.Entity<TaskEntity>().Ignore(x => x.Project);
            modelBuilder.Entity<ProjectEntity>().HasData(projectList);
            modelBuilder.Entity<TaskEntity>().HasData(taskList);
            modelBuilder.Entity<TaskCommentEntity>().HasData(taskCommentList);
        }
    }
}
