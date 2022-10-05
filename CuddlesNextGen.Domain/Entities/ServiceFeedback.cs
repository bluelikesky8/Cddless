using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class ServiceFeedback
    {
        public ServiceFeedback()
        {
            ServiceFeecbackByTypes = new HashSet<ServiceFeecbackByType>();
        }

        public Guid Servicefeedbackid { get; set; }
        public Guid Bookingslotid { get; set; }
        public byte Overallrating { get; set; }
        public string? Feedbacktext { get; set; }
        public DateTime? Feedbackdatetime { get; set; }

        public virtual BookingSlot Bookingslot { get; set; } = null!;
        public virtual ICollection<ServiceFeecbackByType> ServiceFeecbackByTypes { get; set; }
    }
}
