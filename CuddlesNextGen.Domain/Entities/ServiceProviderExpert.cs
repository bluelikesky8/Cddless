using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class ServiceProviderExpert
    {
        public ServiceProviderExpert()
        {
            ServiceProviderExpertNotes = new HashSet<ServiceProviderExpertNote>();
            Threads = new HashSet<Thread>();
        }

        public Guid Serviceproviderexpertid { get; set; }
        public Guid Serviceproviderid { get; set; }
        public Guid Serviceexpertid { get; set; }
        public bool Isactive { get; set; }

        public virtual ServiceExpert Serviceexpert { get; set; } = null!;
        public virtual ServiceProvider Serviceprovider { get; set; } = null!;
        public virtual ICollection<ServiceProviderExpertNote> ServiceProviderExpertNotes { get; set; }
        public virtual ICollection<Thread> Threads { get; set; }
    }
}
