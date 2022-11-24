using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestJob.BL.Models;

namespace TestJob.BL.Services
{
    public class TaskService : ITaskService
    {
        IRepositoryCollection _db;

        public TaskService(IRepositoryCollection db)
        {
            _db = db;
        }

        public async Task Create(TaskDto task)
        {
            await _db.TaskRepository.Create(task);
        }

        public IEnumerable<TaskDto> GetAll()
        {
            var tasks = _db.TaskRepository.GetAll();
            return tasks.ToTaskDtoIEnumerable();
        }

        public IEnumerable<TaskDto> GetAllFiltered(TaskFilter filter)
        {
            var tasks = _db.TaskRepository.GetAllFiltered(filter.Project, filter.Date);
            return tasks.ToTaskDtoIEnumerable();
        }

        public async Task<TaskDto> GetById(Guid id)
        {
            var task = await _db.TaskRepository.GetById(id);
            return new TaskDto(task);
        }

        public async Task Update(Guid id, TaskDto task)
        {
            await _db.TaskRepository.Update(id, task);
        }
    }
}
