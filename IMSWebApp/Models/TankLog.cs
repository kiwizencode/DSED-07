using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMSWebApp.Models
{
    public partial class TankLog
    {
        public TankLog()
        {
            TankLogDaily = new HashSet<TankLogDaily>();
        }

        public int IdPk { get; set; }
        [Display(Name = "Date")]
        public int? PeriodFk { get; set; }
        public int TankFk { get; set; }
        [Display(Name = "Species")]
        public int? SpeciesFk { get; set; }
        [Display(Name = "Description 1")]
        public string SpeciesText { get; set; }
        [Display(Name = "Description 2")]
        public string SpeciesText2 { get; set; }
        public int Qty { get; set; }
        public string Comment { get; set; }
        [Display(Name = "Stuff")]
        public int StuffFk { get; set; }
        public int? OrderFk { get; set; }
        [Display(Name = "Size")]
        public int? SizeFk { get; set; }

        [Display(Name = "Period")]
        public MovementPeriod PeriodFkNavigation { get; set; }
        [Display(Name = "Size")]
        public RecordPetSize SizeFkNavigation { get; set; }
        [Display(Name = "Species")]
        public MarineSpecies SpeciesFkNavigation { get; set; }
        [Display(Name = "Stuff")]
        public SysStuff StuffFkNavigation { get; set; }
        [Display(Name = "Tank")]
        public Tank TankFkNavigation { get; set; }
        public ICollection<TankLogDaily> TankLogDaily { get; set; }
    }
}
