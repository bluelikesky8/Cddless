using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class ServiceExpertService
    {
        public Guid Serviceexpertserviceid { get; set; }
        public Guid Serviceexpertid { get; set; }
        public Guid Serviceid { get; set; }
        public bool Isactive { get; set; }

        public virtual Service Service { get; set; } = null!;
        public virtual ServiceExpert Serviceexpert { get; set; } = null!;
    }
}
