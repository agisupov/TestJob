namespace TestJob.DAL.Models
{
    public interface ITask
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CancelDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public IProject Project { get; set; }
        public IEnumerable<ITaskComment> TaskComments { get; set; }
    }
}
