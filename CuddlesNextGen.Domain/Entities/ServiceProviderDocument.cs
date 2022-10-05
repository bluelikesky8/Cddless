using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class ServiceProviderDocument
    {
        public Guid Serviceproviderdocumentid { get; set; }
        public Guid Serviceproviderid { get; set; }
        public Guid Servicerequireddocumentid { get; set; }
        public Guid Documentid { get; set; }

        public virtual Document Document { get; set; } = null!;
        public virtual ServiceProvider Serviceprovider { get; set; } = null!;
        public virtual ServiceRequiredDocument Servicerequireddocument { get; set; } = null!;
    }
}
