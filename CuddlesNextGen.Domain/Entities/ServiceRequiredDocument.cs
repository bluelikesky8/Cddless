using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class ServiceRequiredDocument
    {
        public ServiceRequiredDocument()
        {
            ServiceExpertDocuments = new HashSet<ServiceExpertDocument>();
            ServiceProviderDocuments = new HashSet<ServiceProviderDocument>();
        }

        public Guid Servicerequireddocumentid { get; set; }
        public string Servicerequireddocumentname { get; set; } = null!;
        public string Servicerequireddocumentfor { get; set; } = null!;
        public Guid? Serviceid { get; set; }
        public Guid? Serviceproviderid { get; set; }

        public virtual Service? Service { get; set; }
        public virtual ServiceProvider? Serviceprovider { get; set; }
        public virtual ICollection<ServiceExpertDocument> ServiceExpertDocuments { get; set; }
        public virtual ICollection<ServiceProviderDocument> ServiceProviderDocuments { get; set; }
    }
}
