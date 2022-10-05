using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class Thread
    {
        public Thread()
        {
            ThreadDocuments = new HashSet<ThreadDocument>();
            ThreadMessages = new HashSet<ThreadMessage>();
        }

        public Guid Threadid { get; set; }
        public Guid Serviceproviderexpertid { get; set; }
        public Guid Memberid { get; set; }
        public bool Isactive { get; set; }

        public virtual Member Member { get; set; } = null!;
        public virtual ServiceProviderExpert Serviceproviderexpert { get; set; } = null!;
        public virtual ICollection<ThreadDocument> ThreadDocuments { get; set; }
        public virtual ICollection<ThreadMessage> ThreadMessages { get; set; }
    }
}
