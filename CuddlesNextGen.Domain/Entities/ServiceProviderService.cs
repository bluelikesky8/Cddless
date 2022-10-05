using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class ServiceProviderService
    {
        public ServiceProviderService()
        {
            SubscriptionPackageDetails = new HashSet<SubscriptionPackageDetail>();
        }

        public Guid Serviceproviderserviceid { get; set; }
        public Guid Serviceproviderid { get; set; }
        public Guid Serviceid { get; set; }
        public bool Isactive { get; set; }

        public virtual Service Service { get; set; } = null!;
        public virtual ServiceProvider Serviceprovider { get; set; } = null!;
        public virtual ICollection<SubscriptionPackageDetail> SubscriptionPackageDetails { get; set; }
    }
}
