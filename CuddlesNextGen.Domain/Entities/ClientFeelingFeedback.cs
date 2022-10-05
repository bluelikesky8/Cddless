using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class ClientFeelingFeedback
    {
        public Guid Clientfeelingfeedbackid { get; set; }
        public Guid Clientid { get; set; }
        public Guid Feelingiconid { get; set; }
        public Guid Bookingslotid { get; set; }
        public string Preorpost { get; set; } = null!;

        public virtual BookingSlot Bookingslot { get; set; } = null!;
        public virtual Client Client { get; set; } = null!;
        public virtual Entity Feelingicon { get; set; } = null!;
    }
}
