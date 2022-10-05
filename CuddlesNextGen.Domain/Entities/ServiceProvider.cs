using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class ServiceProvider
    {
        public ServiceProvider()
        {
            ServiceProviderAddresses = new HashSet<ServiceProviderAddress>();
            ServiceProviderDocuments = new HashSet<ServiceProviderDocument>();
            ServiceProviderExpertServices = new HashSet<ServiceProviderExpertService>();
            ServiceProviderExperts = new HashSet<ServiceProviderExpert>();
            ServiceProviderInvoices = new HashSet<ServiceProviderInvoice>();
            ServiceProviderPaymentInfos = new HashSet<ServiceProviderPaymentInfo>();
            ServiceProviderServices = new HashSet<ServiceProviderService>();
            ServiceRequiredDocuments = new HashSet<ServiceRequiredDocument>();
        }

        public Guid Serviceproviderid { get; set; }
        public string Serviceprovidername { get; set; } = null!;
        public string? Serviceproviderphotopath { get; set; }
        public bool Isactive { get; set; }

        public virtual ICollection<ServiceProviderAddress> ServiceProviderAddresses { get; set; }
        public virtual ICollection<ServiceProviderDocument> ServiceProviderDocuments { get; set; }
        public virtual ICollection<ServiceProviderExpertService> ServiceProviderExpertServices { get; set; }
        public virtual ICollection<ServiceProviderExpert> ServiceProviderExperts { get; set; }
        public virtual ICollection<ServiceProviderInvoice> ServiceProviderInvoices { get; set; }
        public virtual ICollection<ServiceProviderPaymentInfo> ServiceProviderPaymentInfos { get; set; }
        public virtual ICollection<ServiceProviderService> ServiceProviderServices { get; set; }
        public virtual ICollection<ServiceRequiredDocument> ServiceRequiredDocuments { get; set; }
    }
}
