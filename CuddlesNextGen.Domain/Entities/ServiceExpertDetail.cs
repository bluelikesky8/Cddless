using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class ServiceExpertDetail
    {
        public Guid Serviceexpertdetailid { get; set; }
        public Guid Serviceexpertid { get; set; }
        public Guid? Beliefid { get; set; }
        public Guid? Preferredlanguageid { get; set; }
        public Guid? Salulationid { get; set; }
        public string? Specializaion { get; set; }
        public Guid? Durationofserviceid { get; set; }
        public Guid? Countryid { get; set; }
        public Guid? Educationid { get; set; }
        public Guid? Designationid { get; set; }

        public virtual Entity? Belief { get; set; }
        public virtual Entity? Designation { get; set; }
        public virtual Entity? Durationofservice { get; set; }
        public virtual Entity? Education { get; set; }
        public virtual Entity? Preferredlanguage { get; set; }
        public virtual Entity? Salulation { get; set; }
        public virtual ServiceExpert Serviceexpert { get; set; } = null!;
    }
}
