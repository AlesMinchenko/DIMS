using HIMS.BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.BL.Interfaces
{
   public interface ITaskStateService
    {
        IEnumerable<TaskStateDTO> GetTaskStates();
        TaskStateDTO GetTaskState(int? id);
        void Create(TaskStateDTO taskState);
        void Edit(TaskStateDTO taskState);
        void Delete(int? id);
        void Dispose();
    }
}
