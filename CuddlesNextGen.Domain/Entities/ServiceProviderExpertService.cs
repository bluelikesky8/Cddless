using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class ServiceProviderExpertService
    {
        public ServiceProviderExpertService()
        {
            Batches = new HashSet<Batch>();
            SubscriptionPackageDetailMappings = new HashSet<SubscriptionPackageDetailMapping>();
            SubscriptionPackageDetails = new HashSet<SubscriptionPackageDetail>();
        }

        public Guid Serviceproviderexpertserviceid { get; set; }
        public Guid Serviceproviderid { get; set; }
        public Guid Serviceexpertid { get; set; }
        public Guid Serviceid { get; set; }
        public string Serviceduration { get; set; } = null!;
        public decimal Servicecostbyprovider { get; set; }
        public decimal Servicecostformember { get; set; }
        public bool Isactive { get; set; }
        public string? Servicenoteformember { get; set; }

        public virtual Service Service { get; set; } = null!;
        public virtual ServiceExpert Serviceexpert { get; set; } = null!;
        public virtual ServiceProvider Serviceprovider { get; set; } = null!;
        public virtual ICollection<Batch> Batches { get; set; }
        public virtual ICollection<SubscriptionPackageDetailMapping> SubscriptionPackageDetailMappings { get; set; }
        public virtual ICollection<SubscriptionPackageDetail> SubscriptionPackageDetails { get; set; }
    }
}
