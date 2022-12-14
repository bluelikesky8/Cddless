using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class MemberAddress
    {
        public Guid Memberaddressid { get; set; }
        public Guid Memberid { get; set; }
        public string Address { get; set; } = null!;
        public string? City { get; set; }
        public Guid? Stateid { get; set; }
        public Guid? Countryid { get; set; }
        public string? Zipcode { get; set; }

        public virtual Entity? Country { get; set; }
        public virtual Member Member { get; set; } = null!;
        public virtual Entity? State { get; set; }
    }
}
