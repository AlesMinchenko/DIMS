using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.EF.DAL.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Task> Tasks { get; }
        IRepository<UserTrack> UserTracks { get; }
        IRepository<TaskTrack> TaskTracks { get; }

        void Save();
    }
}
