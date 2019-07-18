using HIMS.BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.BL.Interfaces
{
    public interface IUserTrackService
    {
        IEnumerable<UserTrackDTO> GetUserTracks();
        UserTrackDTO GetUserTrack(int? id);
        void Create(UserTrackDTO UserTrack);
        void Edit(UserTrackDTO UserTrack);
        void Delete(int? id);
        void Dispose();
    }
}
