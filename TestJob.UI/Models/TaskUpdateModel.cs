namespace TestJob.UI.Models
{
    public class TaskUpdateModel
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid ProjectId { get; set; }

        public TaskDto AsTaskDto()
        {
            return new TaskDto
            {
                Id = Id,
                TaskName = TaskName,
                StartDate = StartDate,
                CancelDate = EndDate,
                CreateDate = CreateDate,
                UpdateDate = UpdateDate,
                Project = new ProjectDto() { Id = ProjectId }
            };
        }
    }
}
