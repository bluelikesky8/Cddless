using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class ThreadMessage
    {
        public Guid Threadmessageid { get; set; }
        public Guid Threadid { get; set; }
        public Guid Messagefromid { get; set; }
        public DateTime Messagedatetime { get; set; }
        public string Messagetext { get; set; } = null!;

        public virtual User Messagefrom { get; set; } = null!;
        public virtual Thread Thread { get; set; } = null!;
    }
}
