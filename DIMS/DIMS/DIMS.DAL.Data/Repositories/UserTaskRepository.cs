using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.EF.DAL.Data.Repositories
{
    public class UserTaskRepository : IRepository<UserTask>
    {
        private DIMSContext db;

        public UserTaskRepository(DIMSContext context)
        {
            this.db = context;
        }

        public IEnumerable<UserTask> GetAll()
        {
            return db.UserTasks;
        }

        public UserTask Get(int id)
        {
            return db.UserTasks.Find(id);
        }

        public void Create(UserTask userTask)
        {
            db.UserTasks.Add(userTask);
        }

        public void Update(UserTask userTask)
        {
            db.Entry(userTask).State = EntityState.Modified;
        }

        public IEnumerable<UserTask> Find(Func<UserTask, Boolean> predicate)
        {
            return db.UserTasks.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            UserTask userTask = db.UserTasks.Find(id);
            if (userTask != null)
                db.UserTasks.Remove(userTask);
        }
    }
}
