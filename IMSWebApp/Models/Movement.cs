﻿using System;
using System.Collections.Generic;

namespace IMSWebApp.Models
{
    public partial class Movement
    {
        public int IdPk { get; set; }
        public DateTime Timestamp { get; set; }
        public int FromFk { get; set; }
        public int TankFk { get; set; }
        public int IntialQty { get; set; }
        public int QtyMoved { get; set; }
        public int PeriodFk { get; set; }
        public int BatchFk { get; set; }
        public int Day { get; set; }
        public string Comment { get; set; }
    }
}
