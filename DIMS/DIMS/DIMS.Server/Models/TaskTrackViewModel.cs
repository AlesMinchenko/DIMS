using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HIMS.Server.Models
{
    public class TaskTrackViewModel
    {
        public int TaskTrackId { get; set; }
        [Required]
        public int UserTaskId { get; set; }
        [Required]
        [Display(Name = "Track's date")]
        public DateTime TrackDate { get; set; }
        [Required]
        [Display(Name = "Track's note")]
        [StringLength(250, ErrorMessage = "Name should have no less 3 symbols and no more than 250 symbols", MinimumLength = 3)]
        public string TrackNote { get; set; }
    }
}