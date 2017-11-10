using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMSWebApp.Models
{
    public partial class MovementPeriod
    {
        public MovementPeriod()
        {
            TankLog = new HashSet<TankLog>();
        }

        public int IdPk { get; set; }
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        public string Text { get; set; }
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ClosedDate { get; set; }
        [Display(Name = "Closed Flag")]
        public bool ClosedFlag { get; set; } = false;

        public ICollection<TankLog> TankLog { get; set; }
    }
}
