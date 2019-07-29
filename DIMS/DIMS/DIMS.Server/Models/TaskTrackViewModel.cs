﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HIMS.Server.Models
{
    public class TaskTrackViewModel
    {
        public int TaskTrackId { get; set; }
        public int UserTaskId { get; set; }
        public DateTime TrackDate { get; set; }
        public string TrackNote { get; set; }
    }
}