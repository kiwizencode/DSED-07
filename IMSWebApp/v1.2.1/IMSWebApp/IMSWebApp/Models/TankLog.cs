using System;
using System.Collections.Generic;

namespace IMSWebApp.Models
{
    public partial class TankLog
    {
        public TankLog()
        {
            DailyLog = new HashSet<DailyLog>();
        }

        public int IdPk { get; set; }
        public string Comment { get; set; }
        public DateTime PeriodDate { get; set; }
        public int Qty { get; set; }
        public int SpeciesFk { get; set; }
        public int TankId { get; set; }

        public Species SpeciesFkNavigation { get; set; }
        public ICollection<DailyLog> DailyLog { get; set; }
    }
}
