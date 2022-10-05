using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class SubscriptionPackage
    {
        public SubscriptionPackage()
        {
            SubscriptionPackageDetails = new HashSet<SubscriptionPackageDetail>();
        }

        public Guid Subscriptionpackageid { get; set; }
        public string Subscriptionpackagename { get; set; } = null!;
        public decimal Packageamountformember { get; set; }
        public Guid? Batchid { get; set; }
        public short? Durationdays { get; set; }
        public short? Numberofjournalentries { get; set; }
        public bool Isactive { get; set; }
        public bool Isrecurring { get; set; }

        public virtual ICollection<SubscriptionPackageDetail> SubscriptionPackageDetails { get; set; }
    }
}
