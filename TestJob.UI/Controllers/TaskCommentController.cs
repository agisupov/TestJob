using Microsoft.AspNetCore.Mvc;

namespace TestJob.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskCommentController : ControllerBase
    {
        private readonly ServiceManager _manager;

        public TaskCommentController(ServiceManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTaskCommentViewModel taskComment)
        {
            try
            {
                Guid guid = Guid.NewGuid();
                var comment = taskComment.AsCommentDto();
                comment.Id = guid;
                await _manager.TaskCommentService.Create(comment);
                await _manager.Save();
                return Ok(new { id = guid });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _manager.TaskCommentService.Delete(id);
                await _manager.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
