using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class ServiceProviderInvoice
    {
        public ServiceProviderInvoice()
        {
            ServiceProviderPayments = new HashSet<ServiceProviderPayment>();
        }

        public Guid Serviceproviderinvoiceid { get; set; }
        public Guid Memberinvoiceid { get; set; }
        public string Invoicenumber { get; set; } = null!;
        public decimal Invoiceamount { get; set; }
        public DateTime Invoicedatetime { get; set; }
        public Guid Serviceproviderid { get; set; }
        public bool Ispaid { get; set; }

        public virtual MemberInvoice Memberinvoice { get; set; } = null!;
        public virtual ServiceProvider Serviceprovider { get; set; } = null!;
        public virtual ICollection<ServiceProviderPayment> ServiceProviderPayments { get; set; }
    }
}
