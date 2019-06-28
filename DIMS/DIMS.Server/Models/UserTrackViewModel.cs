using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HIMS.Server.Models
{
    public class UserTrackViewModel
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public int TaskTrackId { get; set; }
        public string TaskName { get; set; }
        public string TrackNote { get; set; }
        public DateTime TrackDate { get; set; }
    }
}