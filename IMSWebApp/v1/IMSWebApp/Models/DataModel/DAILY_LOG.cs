using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSWebApp.Models.DataModel
{
    public class DAILY_LOG
    {
        [Key, Required]
        public int ID_PK { get; set; }

        [Column(TypeName = "datetime"), Required]
        [Display(Name = "Daily Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public System.DateTime DAILY_DATE { get; set; }

        [Display(Name = "Tank Log ID"), Required]
        public int LOG_FK { get; set; }

        [Display(Name = "Mortality Reason"), Required]
        public int REASON_FK { get; set; }

        [Display(Name = "Quantity"), Required]
        public int QTY { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Comment")]
        public string COMMENT { get; set; }

        public virtual TANK_LOG TANK_LOG { get; set; }
        public virtual MORTALITY MORTALITY { get; set; }
    }
}
