using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class ServiceProviderPaymentInfo
    {
        public Guid Serviceproviderpaymentinfoid { get; set; }
        public Guid Serviceproviderid { get; set; }
        public string Beneficiaryname { get; set; } = null!;
        public string Accountnumber { get; set; } = null!;
        public string Bankname { get; set; } = null!;
        public string Ifsccode { get; set; } = null!;

        public virtual ServiceProvider Serviceprovider { get; set; } = null!;
    }
}
