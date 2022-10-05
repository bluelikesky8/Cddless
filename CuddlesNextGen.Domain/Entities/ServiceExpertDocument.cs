using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class ServiceExpertDocument
    {
        public Guid Serviceexpertdocumentid { get; set; }
        public Guid Serviceexpertid { get; set; }
        public Guid Servicerequireddocumentid { get; set; }
        public Guid Documentid { get; set; }

        public virtual Document Document { get; set; } = null!;
        public virtual ServiceExpert Serviceexpert { get; set; } = null!;
        public virtual ServiceRequiredDocument Servicerequireddocument { get; set; } = null!;
    }
}
