using System;
using System.Collections.Generic;

namespace IMSWebApp.Models
{
    public partial class TankBay
    {
        public TankBay()
        {
            Tank = new HashSet<Tank>();
        }

        public int IdPk { get; set; }
        public string IdCode { get; set; }
        public string Text { get; set; }

        public ICollection<Tank> Tank { get; set; }
    }
}
