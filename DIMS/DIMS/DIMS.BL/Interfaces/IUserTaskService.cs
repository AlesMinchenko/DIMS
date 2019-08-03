using HIMS.BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.BL.Interfaces
{
    public interface IUserTaskService
    {
        IEnumerable<UserTaskDTO> GetUserTasks();
        UserTaskDTO GetUserTask(int? id);
        void Create(UserTaskDTO userTask);
        void Edit(UserTaskDTO userTask);
        void Delete(int? id);
        void Dispose();
    }
}
