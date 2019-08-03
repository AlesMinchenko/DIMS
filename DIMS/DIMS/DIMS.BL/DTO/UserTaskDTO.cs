using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.BL.DTO
{

    public class UserTaskDTO
    {
        public int UserTaskId { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public int StateId { get; set; }
    }
}
