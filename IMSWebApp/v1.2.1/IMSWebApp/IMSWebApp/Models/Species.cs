using System;
using System.Collections.Generic;

namespace IMSWebApp.Models
{
    public partial class Species
    {
        public Species()
        {
            TankLog = new HashSet<TankLog>();
        }

        public int IdPk { get; set; }
        public string Common { get; set; }
        public string Scientific { get; set; }

        public ICollection<TankLog> TankLog { get; set; }
    }
}
