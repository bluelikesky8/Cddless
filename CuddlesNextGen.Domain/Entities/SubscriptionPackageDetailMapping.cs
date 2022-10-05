using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class SubscriptionPackageDetailMapping
    {
        public Guid Subscriptionpackagedetailmappingid { get; set; }
        public Guid Subscriptionpackagedetailid { get; set; }
        public Guid Serviceproviderexpertserviceid { get; set; }
        public decimal Servicecostbyprovider { get; set; }

        public virtual ServiceProviderExpertService Serviceproviderexpertservice { get; set; } = null!;
        public virtual SubscriptionPackageDetail Subscriptionpackagedetail { get; set; } = null!;
    }
}
