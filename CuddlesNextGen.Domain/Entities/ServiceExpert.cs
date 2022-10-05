using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class ServiceExpert
    {
        public ServiceExpert()
        {
            ServiceExpertDetails = new HashSet<ServiceExpertDetail>();
            ServiceExpertDocuments = new HashSet<ServiceExpertDocument>();
            ServiceExpertServices = new HashSet<ServiceExpertService>();
            ServiceProviderExpertServices = new HashSet<ServiceProviderExpertService>();
            ServiceProviderExperts = new HashSet<ServiceProviderExpert>();
        }

        public Guid Serviceexpertid { get; set; }
        public Guid Userid { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public string? Gender { get; set; }
        public bool Isactive { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<ServiceExpertDetail> ServiceExpertDetails { get; set; }
        public virtual ICollection<ServiceExpertDocument> ServiceExpertDocuments { get; set; }
        public virtual ICollection<ServiceExpertService> ServiceExpertServices { get; set; }
        public virtual ICollection<ServiceProviderExpertService> ServiceProviderExpertServices { get; set; }
        public virtual ICollection<ServiceProviderExpert> ServiceProviderExperts { get; set; }
    }
}
