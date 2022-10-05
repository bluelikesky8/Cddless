using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class BatchSlot
    {
        public BatchSlot()
        {
            BookingSlots = new HashSet<BookingSlot>();
        }

        public Guid Batchslotid { get; set; }
        public Guid Batchid { get; set; }
        public TimeSpan Slotfrom { get; set; }
        public TimeSpan Slotto { get; set; }
        public DateTime Slotdate { get; set; }
        public short? Batchslotmaximumcount { get; set; }
        public short? Batchslotavailablecount { get; set; }

        public virtual Batch Batch { get; set; } = null!;
        public virtual ICollection<BookingSlot> BookingSlots { get; set; }
    }
}
