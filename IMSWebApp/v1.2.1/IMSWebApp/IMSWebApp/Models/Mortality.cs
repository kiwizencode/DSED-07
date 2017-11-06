using System;
using System.Collections.Generic;

namespace IMSWebApp.Models
{
    public partial class Mortality
    {
        public Mortality()
        {
            DailyLog = new HashSet<DailyLog>();
        }

        public int IdPk { get; set; }
        public string Text { get; set; }

        public ICollection<DailyLog> DailyLog { get; set; }
    }
}
