using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMSWebApp.Models
{
    public partial class Tank
    {
        public Tank()
        {
            TankLog = new HashSet<TankLog>();
        }

        public int IdPk { get; set; }
        [Display(Name = "Bay")]
        public int BayFk { get; set; }
        [Display(Name = "Tank ID")]
        public string IdCode { get; set; }
        [Display(Name = "Tank Description")]
        public string Text { get; set; }
        [Display(Name = "RFID Code")]
        public string Rfid { get; set; }

        public TankBay BayFkNavigation { get; set; }
        public ICollection<TankLog> TankLog { get; set; }
    }
}
