using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class ServiceProviderExpertNote
    {
        public Guid Serviceproviderexpertnoteid { get; set; }
        public Guid Serviceproviderexpertid { get; set; }
        public Guid Memberid { get; set; }
        public DateTime Notedatetime { get; set; }
        public string Note { get; set; } = null!;
        public bool Isactive { get; set; }

        public virtual Member Member { get; set; } = null!;
        public virtual ServiceProviderExpert Serviceproviderexpert { get; set; } = null!;
    }
}
