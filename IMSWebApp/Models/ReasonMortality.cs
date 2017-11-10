using System;
using System.Collections.Generic;

namespace IMSWebApp.Models
{
    public partial class ReasonMortality
    {
        public ReasonMortality()
        {
            TankLogDaily = new HashSet<TankLogDaily>();
        }

        public int IdPk { get; set; }
        public string IdCode { get; set; }
        public string Text { get; set; }

        public ICollection<TankLogDaily> TankLogDaily { get; set; }
    }
}
