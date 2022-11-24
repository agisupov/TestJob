namespace TestJob.BL.Extensions
{
    internal static class Extensions
    {
        public static IEnumerable<TaskDto> ToTaskDtoIEnumerable(this IEnumerable<ITask> list) => list.Select(x => new TaskDto(x));

        public static IEnumerable<ProjectDto> ToProjectDtoIEnumerable(this IEnumerable<IProject> list) => list.Select(x => new ProjectDto(x));
    }
}
