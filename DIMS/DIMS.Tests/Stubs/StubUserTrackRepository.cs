using HIMS.EF.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.Tests.Stubs
{
   public class StubUserTrackRepository :IRepository<UserTrack>
    {
        readonly List<UserTrack> _userTracks;

        public StubUserTrackRepository()
        {
            _userTracks = new List<UserTrack>()
            {
                new UserTrack(){  Task = new EF.DAL.Data.Task(), TaskId = 1, TaskName = "Name1", TaskTrack = new TaskTrack(), TaskTrackId = 1, TrackDate = new DateTime(2019, 11, 12).Date, TrackNote="Note1", UserId=1 },
                new UserTrack(){  Task = new EF.DAL.Data.Task(), TaskId = 2, TaskName = "Name2", TaskTrack = new TaskTrack(), TaskTrackId = 2, TrackDate = new DateTime().Date, TrackNote="Note2", UserId=2 },

            };
        }

        public IEnumerable<UserTrack> GetAll()
        {
            return _userTracks.ToList();
        }

        public UserTrack Get(int id)
        {
            return _userTracks.FirstOrDefault(p => p.UserId == id);
        }

        public void Create(UserTrack userTrack)
        {
            _userTracks.Add(userTrack);
        }

        public void Update(UserTrack userTrack)
        {
            var tempUserTrack = _userTracks.FirstOrDefault(x => x.UserId == userTrack.UserId);
            if (tempUserTrack != null)
            {
                tempUserTrack.TaskId = userTrack.TaskId;
                tempUserTrack.Task = userTrack.Task;
                tempUserTrack.TaskName = userTrack.TaskName;
                tempUserTrack.TaskTrack = userTrack.TaskTrack;
                tempUserTrack.TaskTrackId = userTrack.TaskTrackId;
                tempUserTrack.TrackDate = userTrack.TrackDate;
                tempUserTrack.TrackNote = userTrack.TrackNote;
                tempUserTrack.UserId = userTrack.UserId;
            }
        }

        public IEnumerable<UserTrack> Find(Func<UserTrack, Boolean> predicate)
        {
            return _userTracks.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            UserTrack userTrack = _userTracks.FirstOrDefault(x => x.UserId == id);
            if (userTrack != null)
            {
                _userTracks.Remove(userTrack);
            }
        }
    }
}
