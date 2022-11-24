namespace TestJob.DAL.Models
{
    public interface IProject
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public IEnumerable<ITask> Tasks { get; set; }
    }
}
