namespace TestJob.UI.Models
{
    public class CreateTaskViewModel
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid ProjectId { get; set; }

        public TaskDto AsTaskDto()
        {
            return new TaskDto
            {
                Id = Id,
                TaskName = TaskName,
                StartDate = StartDate,
                CancelDate = EndDate,
                Project = new ProjectDto() { Id = ProjectId },
            };
        }
    }
}
