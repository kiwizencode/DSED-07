using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMSWebApp.Models
{
    public partial class TankLogDaily
    {
        public int IdPk { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LogDate { get; set; }
        [Display(Name = "Tank Log Info.")]
        public int LogFk { get; set; }
        [Display(Name = "Reason")]
        public int ReasonFk { get; set; }
        public int Qty { get; set; }
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Comment { get; set; }
        [Display(Name = "Stuff")]
        public int? StuffFk { get; set; }
        [Display(Name = "Tank Info")]
        public TankLog LogFkNavigation { get; set; }
        [Display(Name = "Reason")]
        public ReasonMortality ReasonFkNavigation { get; set; }
        [Display(Name = "Stuff")]
        public SysStuff StuffFkNavigation { get; set; }

    }
}
