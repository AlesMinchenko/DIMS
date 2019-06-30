using HIMS.EF.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIMS.Tests.StubForRepositories
{
    public class StubTaskRepository : IRepository<Task>
    {
        readonly List<Task> _tasks;
        public StubTaskRepository()
        {
            _tasks = new List<Task>()
            {
                new Task()
                {
                    TaskId = 1, DeadlineDate=new DateTime().Date, Description = "discription1", Name = "Alex", StartDate = new DateTime().Date, UserTracks = new List<UserTrack>()
                },
                new Task()
                {
                    TaskId = 2, DeadlineDate=new DateTime().Date, Description = "discription2", Name = "Petr", StartDate = new DateTime().Date, UserTracks = new List<UserTrack>(),
                },
                new Task()
                {
                    TaskId = 3, DeadlineDate=new DateTime().Date, Description = "discription3", Name = "Ivan", StartDate = new DateTime().Date, UserTracks = new List<UserTrack>(),
                }
            };
        }
        public IEnumerable<Task> GetAll()
        {
            return _tasks.ToList();
        }
        public Task Get(int id)
        {
            return _tasks.FirstOrDefault(i => i.TaskId == id);
        }
        public void Create(Task task)
        {
            _tasks.Add(task);
        }
        public void Update(Task task)
        {
            var tempTask = _tasks.FirstOrDefault(i => i.TaskId == task.TaskId);
            if (tempTask != null)
            {
                tempTask.TaskId = task.TaskId;
                tempTask.StartDate = task.StartDate;
                tempTask.Name = task.Name;
                tempTask.Description = task.Description;
                tempTask.DeadlineDate = tempTask.DeadlineDate;
                tempTask.UserTracks = task.UserTracks;
            }
        }
        public IEnumerable<Task> Find(Func<Task, bool> predicate)
        {
            return _tasks.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            var tempTask = _tasks.Find(i => i.TaskId == id);
            _tasks.Remove(tempTask);
        }


    }
}
