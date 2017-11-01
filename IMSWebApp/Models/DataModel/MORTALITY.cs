using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMSWebApp.Models.DataModel
{
    public partial class MORTALITY
    {
        public MORTALITY()
        {
            this.DAILY_LOG = new HashSet<DAILY_LOG>();
        }
        [Key]
        public int ID_PK { get; set; }
        [Display(Name = "Mortality Reason")]
        public string TEXT { get; set; }

        public virtual ICollection<DAILY_LOG> DAILY_LOG { get; set; }
    }
}
