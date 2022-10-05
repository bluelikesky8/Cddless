using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class BookingSlotServiceInfo
    {
        public Guid Bookingslotserviceinfoid { get; set; }
        public Guid Bookingslotid { get; set; }
        public bool Isdiagnosedbefore { get; set; }
        public string? Diagnosis { get; set; }
        public bool Takingmedicine { get; set; }

        public virtual BookingSlot Bookingslot { get; set; } = null!;
    }
}
