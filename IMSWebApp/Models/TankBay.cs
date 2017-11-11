using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMSWebApp.Models
{
    public partial class TankBay
    {
        public TankBay()
        {
            Tank = new HashSet<Tank>();
        }

        public int IdPk { get; set; }
        [Display(Name = "Id Number")]
        public string IdCode { get; set; }
        [Display(Name = "Description")]
        public string Text { get; set; }

        public ICollection<Tank> Tank { get; set; }
    }
}
