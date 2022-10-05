using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class Service
    {
        public Service()
        {
            ServiceExpertServices = new HashSet<ServiceExpertService>();
            ServiceProviderExpertServices = new HashSet<ServiceProviderExpertService>();
            ServiceProviderServices = new HashSet<ServiceProviderService>();
            ServiceRequiredDocuments = new HashSet<ServiceRequiredDocument>();
            SubscriptionPackageDetails = new HashSet<SubscriptionPackageDetail>();
        }

        public Guid Serviceid { get; set; }
        public string Servicename { get; set; } = null!;
        public byte[]? Serviceimage { get; set; }
        public Guid Servicecategoryid { get; set; }
        public bool Isactive { get; set; }

        public virtual ServiceCategory Servicecategory { get; set; } = null!;
        public virtual ICollection<ServiceExpertService> ServiceExpertServices { get; set; }
        public virtual ICollection<ServiceProviderExpertService> ServiceProviderExpertServices { get; set; }
        public virtual ICollection<ServiceProviderService> ServiceProviderServices { get; set; }
        public virtual ICollection<ServiceRequiredDocument> ServiceRequiredDocuments { get; set; }
        public virtual ICollection<SubscriptionPackageDetail> SubscriptionPackageDetails { get; set; }
    }
}
