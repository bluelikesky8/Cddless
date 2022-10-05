using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class Tribe
    {
        public Tribe()
        {
            TribeComments = new HashSet<TribeComment>();
        }

        public Guid Tribeid { get; set; }
        public Guid Journalid { get; set; }
        public DateTime Publishdatetiime { get; set; }
        public bool Isactive { get; set; }

        public virtual Journal Journal { get; set; } = null!;
        public virtual ICollection<TribeComment> TribeComments { get; set; }
    }
}
