using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class ThreadDocument
    {
        public Guid Threaddocumentid { get; set; }
        public Guid Threadid { get; set; }
        public Guid Documentfromid { get; set; }
        public DateTime Documentdatetime { get; set; }
        public Guid Documentid { get; set; }

        public virtual Document Document { get; set; } = null!;
        public virtual User Documentfrom { get; set; } = null!;
        public virtual Thread Thread { get; set; } = null!;
    }
}
