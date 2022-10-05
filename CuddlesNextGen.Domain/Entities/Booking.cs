using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class Booking
    {
        public Booking()
        {
            BookingSlots = new HashSet<BookingSlot>();
            MemberInvoices = new HashSet<MemberInvoice>();
        }

        public Guid Bookingid { get; set; }
        public Guid Memberid { get; set; }
        public string Bookingnumber { get; set; } = null!;
        public DateTime Bookingdatetime { get; set; }
        public Guid Servicemodeid { get; set; }
        public Guid Subscriptionpackageid { get; set; }
        public bool? Isrecurring { get; set; }

        public virtual Member Member { get; set; } = null!;
        public virtual Entity Servicemode { get; set; } = null!;
        public virtual ICollection<BookingSlot> BookingSlots { get; set; }
        public virtual ICollection<MemberInvoice> MemberInvoices { get; set; }
    }
}
