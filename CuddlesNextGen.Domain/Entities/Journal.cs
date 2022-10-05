using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class Journal
    {
        public Journal()
        {
            Tribes = new HashSet<Tribe>();
        }

        public Guid Journalid { get; set; }
        public string Journaltitle { get; set; } = null!;
        public string Journaltext { get; set; } = null!;
        public string? Journalphotopath { get; set; }
        public string? Journaltags { get; set; }
        public Guid Userid { get; set; }
        public bool Isactive { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Tribe> Tribes { get; set; }
    }
}
