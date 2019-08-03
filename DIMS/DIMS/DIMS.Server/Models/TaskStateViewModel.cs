using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HIMS.Server.Models
{
    public class TaskStateViewModel
    {
        public int StateId { get; set; }
        [Required]
        [Display(Name = "State's name")]
        [StringLength(50, ErrorMessage = "Name should have no less 3 symbols and no more than 50 symbols", MinimumLength = 3)]
        public string StateName { get; set; }
    }
}