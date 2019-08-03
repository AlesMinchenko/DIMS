using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HIMS.Server.Models
{
    public class UserTaskViewModel
    {
        public int UserTaskId { get; set; }
        [Required]
        [Display(Name = "Task id")]
        public int TaskId { get; set; }
        [Required]
        [Display(Name = "User id")]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "State id")]
        public int StateId { get; set; }
    }
}