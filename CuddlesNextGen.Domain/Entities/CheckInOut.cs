using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class CheckInOut
    {
        public Guid Checkinoutid { get; set; }
        public Guid Bookingslotid { get; set; }
        public Guid Userid { get; set; }
        public DateTime? Checkindatetime { get; set; }
        public DateTime? Checkoutdatetime { get; set; }

        public virtual BookingSlot Bookingslot { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
