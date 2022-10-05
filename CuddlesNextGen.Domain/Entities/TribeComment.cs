using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class TribeComment
    {
        public Guid Tribecommentid { get; set; }
        public Guid Tribeid { get; set; }
        public Guid Userid { get; set; }
        public string Commenttext { get; set; } = null!;
        public DateTime Commentdatetime { get; set; }

        public virtual Tribe Tribe { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
