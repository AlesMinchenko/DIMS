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
        void Create(TaskDTO chart);
        void Edit(TaskDTO chart);
        void Delete(int? id);
        void Dispose();
    }
}
