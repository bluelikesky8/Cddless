using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class ClientSafetyPlan
    {
        public Guid Clientsafetyplanid { get; set; }
        public Guid Clientid { get; set; }
        public string? Referwhen { get; set; }
        public string? Callfamily { get; set; }
        public string? Callfriends { get; set; }
        public string? Callothers { get; set; }
        public string? Thingstocalm { get; set; }
        public string? Thingstomakeenvsafe { get; set; }
        public string? Needprofessionalsupport { get; set; }

        public virtual Client Client { get; set; } = null!;
    }
}
