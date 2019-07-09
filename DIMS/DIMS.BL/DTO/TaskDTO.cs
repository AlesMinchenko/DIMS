using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.BL.DTO
{
    public class TaskDTO
    {
        [Key]
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeadlineDate { get; set; }

        //public virtual ICollection<UserTrackDTO> UserTracks { get; set; }

        ////public TaskDTO()
        ////{
        ////    //this.UserTracks = new HashSet<UserTrack>();
        ////    UserTracks = new List<UserTrackDTO>();
        ////}
    }
}
