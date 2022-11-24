using Microsoft.AspNetCore.Mvc;
using TestJob.BL.Filter;

namespace TestJob.UI.Controllers
{
    public class TaskController : Controller
    {
        private readonly ServiceManager _manager;
        private readonly ILogger<TaskController> _logger;

        public TaskController(ILogger<TaskController> logger, ServiceManager manager)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpGet("/")]
        public IActionResult Index(string project, string date)
        {
            IEnumerable<TaskDto> tasks;
            if (project == null && date == default)
            {
                tasks = _manager.TaskService.GetAll();
            }
            else
            {
                var filter = new TaskFilter() { Project = project, Date = date };
                tasks = _manager.TaskService.GetAllFiltered(filter);
            }
            var projects = _manager.ProjectService.GetAll();
            var page = new TaskTablePageViewModel(tasks, projects);
            return View(page);
        }

        [HttpGet("/task/{id}")]
        public async Task<IActionResult> GetTask(Guid id)
        {
            try
            {
                var task = await _manager.TaskService.GetById(id);
                var projects = _manager.ProjectService.GetAll();
                var taskView = new TaskPageViewModel(task, projects);
                return View(taskView);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TaskUpdateModel model)
        {
            try
            {
                await _manager.TaskService.Update(id, model.AsTaskDto());
                await _manager.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpPost("/task")]
        public async Task<IActionResult> Post([FromBody] TaskCommentViewModel obj)
        {
            try
            {
                var id = Guid.NewGuid();
                var commentId = Guid.NewGuid();
                obj.Task.Id = id;
                obj.TaskComment.Id = commentId;
                obj.TaskComment.TaskId = id;
                await _manager.TaskService.Create(obj.Task.AsTaskDto());
                await _manager.TaskCommentService.Create(obj.TaskComment.AsCommentDto());
                await _manager.Save();
                return Ok(new { id = id });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
