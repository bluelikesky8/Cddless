using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class MemberPaymentInfo
    {
        public Guid Memberpaymentinfoid { get; set; }
        public Guid Memberid { get; set; }
        public string Creditcardnumber { get; set; } = null!;
        public DateTime Expirydate { get; set; }
        public string Nameoncard { get; set; } = null!;

        public virtual Member Member { get; set; } = null!;
    }
}
