using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMSWebApp.Models.DataModel
{
    public class DAILY_LOG
    {
        [Key]
        public int ID_PK { get; set; }
        [Display(Name = "Daily Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public System.DateTime DAILY_DATE { get; set; }
        [Display(Name = "Tank Log ID")]
        public int LOG_FK { get; set; }
        [Display(Name = "Mortality Reason")]
        public int REASON_FK { get; set; }
        [Display(Name = "Quantity")]
        public int QTY { get; set; }
        [Display(Name = "Comment")]
        public string COMMENT { get; set; }

        public virtual TANK_LOG TANK_LOG { get; set; }
        public virtual MORTALITY MORTALITY { get; set; }
    }
}
