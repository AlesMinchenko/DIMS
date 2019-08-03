using HIMS.BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.BL.Interfaces
{
    public interface ITaskService
    {
        IEnumerable<TaskDTO> GetTasks();
        TaskDTO GetTask(int? id);
        void Create(TaskDTO task);
        void Edit(TaskDTO task);
        void Delete(int? id);
        void Dispose();
    }
}
