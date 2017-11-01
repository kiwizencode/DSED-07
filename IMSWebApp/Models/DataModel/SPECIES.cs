using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMSWebApp.Models.DataModel
{
    public partial class SPECIES
    {
        public SPECIES()
        {
            this.TANK_LOG = new HashSet<TANK_LOG>();
        }

        public int ID_PK { get; set; }
        [Display(Name = "Scientific Name")]
        public string SCIENTIFIC { get; set; }
        [Display(Name = "Common Name")]
        public string COMMON { get; set; }

        public virtual ICollection<TANK_LOG> TANK_LOG { get; set; }
    }
}
