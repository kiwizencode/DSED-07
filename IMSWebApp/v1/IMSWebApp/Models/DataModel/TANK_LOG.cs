using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSWebApp.Models.DataModel
{
    public partial class TANK_LOG
    {
        public TANK_LOG()
        {
          this.DAILY_LOG = new HashSet<DAILY_LOG>();
        }
        [Key, Required]
        public int ID_PK { get; set; }

        [Column(TypeName = "datetime"), Required]
        [Display(Name = "Period Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public System.DateTime PERIOD_DATE { get; set; }

        [Display(Name = "Tank ID"), Required]
        public int TANK_ID { get; set; }

        [Display(Name = "Species ID"), Required]
        public int SPECIES_FK { get; set; }
        public virtual SPECIES SPECIES { get; set; }

        [Display(Name = "Qunatity"), Required]
        public int QTY { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Comment")]
        public string COMMENT { get; set; }

        public virtual ICollection<DAILY_LOG> DAILY_LOG { get; set; }
    }
}
