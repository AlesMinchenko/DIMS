using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.EF.DAL.Data.Repositories
{
    public class TaskTrackRepository : IRepository<TaskTrack>
    {
        private DIMSContext db;

        public TaskTrackRepository(DIMSContext context)
        {
            this.db = context;
        }

        public IEnumerable<TaskTrack> GetAll()
        {
            return db.TaskTracks;
        }

        public TaskTrack Get(int id)
        {
            return db.TaskTracks.Find(id);
        }

        public void Create(TaskTrack taskTrack)
        {
            db.TaskTracks.Add(taskTrack);
        }

        public void Update(TaskTrack taskTrack)
        {
            db.Entry(taskTrack).State = EntityState.Modified;
        }

        public IEnumerable<TaskTrack> Find(Func<TaskTrack, Boolean> predicate)
        {
            return db.TaskTracks.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            TaskTrack taskTrack = db.TaskTracks.Find(id);
            if (taskTrack != null)
                db.TaskTracks.Remove(taskTrack);
        }
    }
}
