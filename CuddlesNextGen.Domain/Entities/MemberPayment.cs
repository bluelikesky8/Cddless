using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class MemberPayment
    {
        public Guid Memberpaymentid { get; set; }
        public Guid Memberinvoiceid { get; set; }
        public decimal Paymentamount { get; set; }
        public DateTime Paymentdatetime { get; set; }
        public Guid Paymentmodeid { get; set; }

        public virtual MemberInvoice Memberinvoice { get; set; } = null!;
        public virtual Entity Paymentmode { get; set; } = null!;
    }
}
