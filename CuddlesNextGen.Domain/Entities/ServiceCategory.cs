using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class ServiceCategory
    {
        public ServiceCategory()
        {
            InverseParentservicecategory = new HashSet<ServiceCategory>();
            Services = new HashSet<Service>();
        }

        public Guid Servicecategoryid { get; set; }
        public string Servicecategoryname { get; set; } = null!;
        public byte[]? Servicecategoryimage { get; set; }
        public bool Isactive { get; set; }
        public Guid? Parentservicecategoryid { get; set; }

        public virtual ServiceCategory? Parentservicecategory { get; set; }
        public virtual ICollection<ServiceCategory> InverseParentservicecategory { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
