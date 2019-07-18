using HIMS.EF.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIMS.Tests.Stubs
{
    public class StubTaskRepository : IRepository<Task>
    {
        readonly List<Task> _tasks;

        public StubTaskRepository()
        {
            _tasks = new List<Task>()
            {
                new Task(){ DeadlineDate = new DateTime().Date, Description="Description1", Name = "Name1", StartDate=new DateTime().Date, TaskId =1, UserTracks=new List<UserTrack>() },
                new Task(){ DeadlineDate = new DateTime().Date, Description="Description2", Name = "Name12", StartDate=new DateTime().Date, TaskId =3, UserTracks=new List<UserTrack>() },

            };
        }

        public IEnumerable<Task> GetAll()
        {
            return _tasks.ToList();
        }

        public Task Get(int id)
        {
            return _tasks.FirstOrDefault(p => p.TaskId == id);
        }

        public void Create(Task task)
        {
            _tasks.Add(task);
        }

        public void Update(Task task)
        {
            var tempTask = _tasks.FirstOrDefault(x => x.TaskId == task.TaskId);
            if (tempTask != null)
            {
                tempTask.TaskId = task.TaskId;
                tempTask.Name = task.Name;
                tempTask.DeadlineDate = task.DeadlineDate;
                tempTask.StartDate = task.StartDate;
                tempTask.UserTracks = task.UserTracks;
                tempTask.Description = task.Description;
            }
        }

        public IEnumerable<Task> Find(Func<Task, Boolean> predicate)
        {
            return _tasks.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Task task = _tasks.FirstOrDefault(x => x.TaskId == id);
            if (task != null)
            {
                _tasks.Remove(task);
            }
        }
    }
}
