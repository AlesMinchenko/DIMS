﻿using HIMS.BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.BL.Interfaces
{
    public interface ITaskTrackService
    {
        IEnumerable<TaskTrackDTO> GetTaskTracks();
        TaskTrackDTO GetTaskTrack(int? id);
        void Create(TaskTrackDTO taskTrack);
        void Edit(TaskTrackDTO taskTrack);
        void Delete(int? id);
        void Dispose();
    }
}
