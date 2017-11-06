using System;
using System.Collections.Generic;

namespace IMSWebApp.Models
{
    public partial class DailyLog
    {
        public int IdPk { get; set; }
        public string Comment { get; set; }
        public DateTime DailyDate { get; set; }
        public int LogFk { get; set; }
        public int Qty { get; set; }
        public int ReasonFk { get; set; }

        public TankLog LogFkNavigation { get; set; }
        public Mortality ReasonFkNavigation { get; set; }
    }
}
