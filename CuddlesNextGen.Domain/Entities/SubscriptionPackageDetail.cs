using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class SubscriptionPackageDetail
    {
        public SubscriptionPackageDetail()
        {
            SubscriptionPackageDetailMappings = new HashSet<SubscriptionPackageDetailMapping>();
        }

        public Guid Subscriptionpackagedetailid { get; set; }
        public Guid Subscriptionpackageid { get; set; }
        public Guid? Serviceid { get; set; }
        public Guid? Serviceproviderserviceid { get; set; }
        public Guid? Serviceproviderexpertserviceid { get; set; }
        public short Numberofbatchslots { get; set; }

        public virtual Service? Service { get; set; }
        public virtual ServiceProviderExpertService? Serviceproviderexpertservice { get; set; }
        public virtual ServiceProviderService? Serviceproviderservice { get; set; }
        public virtual SubscriptionPackage Subscriptionpackage { get; set; } = null!;
        public virtual ICollection<SubscriptionPackageDetailMapping> SubscriptionPackageDetailMappings { get; set; }
    }
}
