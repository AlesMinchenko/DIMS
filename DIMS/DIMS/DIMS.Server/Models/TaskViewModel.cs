using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HIMS.Server.Models
{
    public class TaskViewModel
    {
        public int TaskId { get; set; }
        [Required]
        [Display(Name = "Task's name")]
        [StringLength(50, ErrorMessage = "Name should have no less 3 symbols and no more than 50 symbols", MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Description should have no less than 3 symbols and no more than 10 ", MinimumLength = 3)]
        public string Description { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeadlineDate { get; set; }

    }
}