using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMSWebApp.Models
{
    public partial class ReasonMortality
    {
        public ReasonMortality()
        {
            TankLogDaily = new HashSet<TankLogDaily>();
        }

        public int IdPk { get; set; }
        [Display(Name = "Code")]
        public string IdCode { get; set; }
        [Display(Name = "Reason")]
        public string Text { get; set; }

        public ICollection<TankLogDaily> TankLogDaily { get; set; }
    }
}
