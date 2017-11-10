using System;
using System.Collections.Generic;

namespace IMSWebApp.Models
{
    public partial class RecordGroup
    {
        public RecordGroup()
        {
            RecordPet = new HashSet<RecordPet>();
        }

        public int IdPk { get; set; }
        public string Description { get; set; }

        public ICollection<RecordPet> RecordPet { get; set; }
    }
}
