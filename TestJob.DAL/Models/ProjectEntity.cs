namespace TestJob.DAL.Models
{
    public class ProjectEntity : IProject
    {
        public ProjectEntity()
        {

        }

        public ProjectEntity(IProject project)
        {
            Id = project.Id;
            ProjectName = project.ProjectName;
            CreateDate = project.CreateDate;
            UpdateDate = project.UpdateDate;
        }

        public Guid Id { get; set; }
        [MaxLength(255)]
        public string ProjectName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public virtual ICollection<TaskEntity> Tasks { get; set; }

        IEnumerable<ITask> IProject.Tasks
        {
            get => Tasks; 
            set => Tasks = value as ICollection<TaskEntity>;
        }
    }
}
