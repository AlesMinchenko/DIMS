using HIMS.EF.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIMS.Tests.StubForRepositories
{
    public class StubUserTrackRepository : IRepository<UserTrack>
    {
        List<UserTrack> _userTracks;
        public StubUserTrackRepository()
        {
            _userTracks = new List<UserTrack>()
            {
                new UserTrack()
                {
                    Task = new Task(), TaskId = 1, TaskName ="Name1", TaskTrack = new TaskTrack(), TaskTrackId = 1, TrackDate = new DateTime().Date, TrackNote = "Note1", UserId=1
                },
                new UserTrack()
                {
                    Task = new Task(), TaskId = 2, TaskName ="Name2", TaskTrack = new TaskTrack(), TaskTrackId = 2, TrackDate = new DateTime().Date, TrackNote = "Note2", UserId=2
                },
                new UserTrack()
                {
                    Task = new Task(), TaskId = 3, TaskName ="Name3", TaskTrack = new TaskTrack(), TaskTrackId = 3, TrackDate = new DateTime().Date, TrackNote = "Note3", UserId=3
                },
            };
        }
        public IEnumerable<UserTrack> GetAll()
        {
            return _userTracks.ToList();
        }
        public UserTrack Get(int id)
        {
            return _userTracks.FirstOrDefault(i => i.UserId == id);
        }
        public void Create(UserTrack userTrack)
        {
            _userTracks.Add(userTrack);
        }
        public void Update(UserTrack userTrack)
        {
            var tempUserTrack = _userTracks.FirstOrDefault(i => i.UserId == userTrack.UserId);
            if (tempUserTrack != null)
            {
                tempUserTrack.UserId = userTrack.UserId;
                tempUserTrack.TrackNote = userTrack.TrackNote;
                tempUserTrack.TrackDate = userTrack.TrackDate;
                tempUserTrack.TaskTrackId = userTrack.TaskTrackId;
                tempUserTrack.TaskTrack = userTrack.TaskTrack;
                tempUserTrack.TaskName = userTrack.TaskName;
                tempUserTrack.TaskId = userTrack.TaskId;
                tempUserTrack.Task = userTrack.Task;
            }
        }
        public IEnumerable<UserTrack> Find(Func<UserTrack, bool> predicate)
        {
            return _userTracks.Where(predicate).ToList();
        }
        public void Delete (int id)
        {
            var tempuserTrack = _userTracks.FirstOrDefault(i => i.UserId == id);
            _userTracks.Remove(tempuserTrack);
        }
    }
}
