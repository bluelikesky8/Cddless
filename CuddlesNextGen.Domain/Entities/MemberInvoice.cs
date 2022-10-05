using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class MemberInvoice
    {
        public MemberInvoice()
        {
            MemberPayments = new HashSet<MemberPayment>();
            ServiceProviderInvoices = new HashSet<ServiceProviderInvoice>();
        }

        public Guid Memberinvoiceid { get; set; }
        public Guid Bookingid { get; set; }
        public string Invoicenumber { get; set; } = null!;
        public decimal Invoiceamount { get; set; }
        public DateTime Invoicedatetime { get; set; }
        public bool Ispaid { get; set; }

        public virtual Booking Booking { get; set; } = null!;
        public virtual ICollection<MemberPayment> MemberPayments { get; set; }
        public virtual ICollection<ServiceProviderInvoice> ServiceProviderInvoices { get; set; }
    }
}
