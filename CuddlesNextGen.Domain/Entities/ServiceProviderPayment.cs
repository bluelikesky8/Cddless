using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class ServiceProviderPayment
    {
        public Guid Serviceproviderpaymentid { get; set; }
        public Guid Serviceproviderinvoiceid { get; set; }
        public decimal Paymentamount { get; set; }
        public DateTime Paymentdatetime { get; set; }
        public Guid Paymentmodeid { get; set; }

        public virtual Entity Paymentmode { get; set; } = null!;
        public virtual ServiceProviderInvoice Serviceproviderinvoice { get; set; } = null!;
    }
}
