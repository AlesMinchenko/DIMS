using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.EF.DAL.Data.Repositories
{
    public class UserTrackRepository : IRepository<UserTrack>
    {
        private DIMSContext db;

        public UserTrackRepository(DIMSContext context)
        {
            this.db = context;
        }

        public IEnumerable<UserTrack> GetAll()
        {
            return db.UserTracks;
        }

        public UserTrack Get(int id)
        {
            return db.UserTracks.Find(id);
        }

        public void Create(UserTrack userTrack)
        {
            db.UserTracks.Add(userTrack);
        }

        public void Update(UserTrack userTrack)
        {
            db.Entry(userTrack).State = EntityState.Modified;
        }

        public IEnumerable<UserTrack> Find(Func<UserTrack, Boolean> predicate)
        {
            return db.UserTracks.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            UserTrack userTrack = db.UserTracks.Find(id);
            if (userTrack != null)
                db.UserTracks.Remove(userTrack);
        }
    }
}
