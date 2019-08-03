using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.EF.DAL.Data.Repositories
{
    public class TaskStateRepository : IRepository<TaskState>
    {
        private DIMSContext db;

        public TaskStateRepository(DIMSContext context)
        {
            this.db = context;
        }

        public IEnumerable<TaskState> GetAll()
        {
            return db.TaskStates;
        }

        public TaskState Get(int id)
        {
            return db.TaskStates.Find(id);
        }

        public void Create(TaskState taskState)
        {
            db.TaskStates.Add(taskState);
        }

        public void Update(TaskState taskState)
        {
            db.Entry(taskState).State = EntityState.Modified;
        }

        public IEnumerable<TaskState> Find(Func<TaskState, Boolean> predicate)
        {
            return db.TaskStates.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            TaskState taskState = db.TaskStates.Find(id);
            if (taskState != null)
                db.TaskStates.Remove(taskState);
        }
    }
}
