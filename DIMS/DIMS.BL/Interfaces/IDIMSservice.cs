using HIMS.BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.BL.Interfaces
{
    public interface IDIMSService
    {
        IEnumerable<UserTrackDTO> GetUserTracks();
        UserTrackDTO GetUserTrack(int? id);
        void CreateU(UserTrackDTO UserTrack);
        void Edit(UserTrackDTO UserTrack);
        void DeleteU(int? id);

        IEnumerable<TaskDTO> GetTasks();
        TaskDTO GetTask(int? id);
        void CreateT(TaskDTO chart);
        void Edit(TaskDTO chart);
        void DeleteT(int? id);


        void Dispose();

    }
}
