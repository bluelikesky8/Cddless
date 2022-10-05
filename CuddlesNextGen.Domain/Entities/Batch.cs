using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class Batch
    {
        public Batch()
        {
            BatchSlots = new HashSet<BatchSlot>();
        }

        public Guid Batchid { get; set; }
        public Guid Serviceproviderexpertserviceid { get; set; }
        public string Batchname { get; set; } = null!;
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public short? Batchmaximumcount { get; set; }
        public short? Batchavailablecount { get; set; }

        public virtual ServiceProviderExpertService Serviceproviderexpertservice { get; set; } = null!;
        public virtual ICollection<BatchSlot> BatchSlots { get; set; }
    }
}
