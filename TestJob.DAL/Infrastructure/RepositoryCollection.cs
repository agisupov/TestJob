using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestJob.DAL.Data;
using TestJob.DAL.Repositories;

namespace TestJob.DAL.Infrastructure
{
    public class RepositoryCollection : IRepositoryCollection
    {
        private readonly DataContext _db;
        private DataProjectRepository _projectRepository;
        private DataTaskRepository _taskRepository;
        private DataTaskCommentRepository _commentRepository;

        public RepositoryCollection(DataContext db)
        {
            _db = db;
        }

        public IProjectRepository ProjectRepository
        {
            get 
            { 
                if (_projectRepository == null) 
                { 
                    _projectRepository = new DataProjectRepository(_db); 
                }
                return _projectRepository;
            }
        }

        public ITaskRepository TaskRepository
        {
            get
            {
                if (_projectRepository == null) 
                { 
                    _taskRepository = new DataTaskRepository(_db);
                }
                return _taskRepository;
            }
        }

        public ITaskCommentRepository TaskCommentRepository
        {
            get 
            { 
                if (_commentRepository == null)
                {
                    _commentRepository = new DataTaskCommentRepository(_db);
                }
                return _commentRepository;
            }
        }

        public async ValueTask DisposeAsync()
        {
            await _db.DisposeAsync();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
