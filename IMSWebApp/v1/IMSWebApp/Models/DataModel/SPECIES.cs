using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSWebApp.Models.DataModel
{

  /* How to specify the data type of a particular column to which the property of the class mapped to
     https://docs.microsoft.com/en-us/ef/core/modeling/relational/data-types  */

  /* https://docs.microsoft.com/en-us/ef/core/modeling/keys
   * https://docs.microsoft.com/en-us/ef/core/modeling/required-optional */

  public partial class SPECIES
    {
        public SPECIES()
        {
            this.TANK_LOG = new HashSet<TANK_LOG>();
        }

        [Key, Required]
        public int ID_PK { get; set; }

        [Column(TypeName = "nvarchar(50)"), Required]
        [Display(Name = "Scientific Name")]
        public string SCIENTIFIC { get; set; }

        [Column(TypeName = "nvarchar(100)"), Required]
        [Display(Name = "Common Name")]
        public string COMMON { get; set; }

        public virtual ICollection<TANK_LOG> TANK_LOG { get; set; }
    }
}
