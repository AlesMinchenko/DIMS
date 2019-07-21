using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HIMS.Server.Models
{
    public class UserTrackViewModel
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public int TaskTrackId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name should contain no less 3 and no more than 50 symbols", MinimumLength = 3)]
        public string TaskName { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Note should contain no less 3 and no more than 250 symbols", MinimumLength = 5)]
        public string TrackNote { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime TrackDate { get; set; }
    }
}