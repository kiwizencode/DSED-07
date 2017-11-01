using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMSWebApp.Models.DataModel
{
    public partial class TANK_LOG
    {

        public TANK_LOG()
        {
          this.DAILY_LOG = new HashSet<DAILY_LOG>();
        }

        public int ID_PK { get; set; }
        [Display(Name = "Period Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public System.DateTime PERIOD_DATE { get; set; }
        [Display(Name = "Tank ID")]
        public int TANK_ID { get; set; }
        [Display(Name = "Species ID")]
        public int SPECIES_FK { get; set; }
        [Display(Name = "Qunatity")]
        public int QTY { get; set; }
        [Display(Name = "Comment")]
        public string COMMENT { get; set; }

        public virtual SPECIES SPECIES { get; set; }
        public virtual ICollection<DAILY_LOG> DAILY_LOG { get; set; }
    }
}
