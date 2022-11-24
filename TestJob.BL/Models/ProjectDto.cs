namespace TestJob.BL.Models
{
    public class ProjectDto : IProject
    {
        public ProjectDto()
        {

        }

        public ProjectDto(IProject obj)
        {
            Id = obj.Id;
            ProjectName = obj.ProjectName;
            CreateDate = obj.CreateDate;
            UpdateDate = obj.UpdateDate;
            Tasks = obj.Tasks;
        }

        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public IEnumerable<ITask> Tasks { get; set; }
    }
}
