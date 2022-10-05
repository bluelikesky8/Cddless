using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class BookingSlot
    {
        public BookingSlot()
        {
            BookingSlotServiceInfos = new HashSet<BookingSlotServiceInfo>();
            CheckInOuts = new HashSet<CheckInOut>();
            ClientFeelingFeedbacks = new HashSet<ClientFeelingFeedback>();
            ServiceFeedbacks = new HashSet<ServiceFeedback>();
        }

        public Guid Bookingslotid { get; set; }
        public Guid Bookingid { get; set; }
        public Guid Batchslotid { get; set; }
        public Guid Bookingslotstatusid { get; set; }
        public decimal? Servicecostbyprovider { get; set; }
        public decimal? Servicecostformember { get; set; }

        public virtual BatchSlot Batchslot { get; set; } = null!;
        public virtual Booking Booking { get; set; } = null!;
        public virtual Entity Bookingslotstatus { get; set; } = null!;
        public virtual ICollection<BookingSlotServiceInfo> BookingSlotServiceInfos { get; set; }
        public virtual ICollection<CheckInOut> CheckInOuts { get; set; }
        public virtual ICollection<ClientFeelingFeedback> ClientFeelingFeedbacks { get; set; }
        public virtual ICollection<ServiceFeedback> ServiceFeedbacks { get; set; }
    }
}
