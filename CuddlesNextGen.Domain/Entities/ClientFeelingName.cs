using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class ClientFeelingName
    {
        public Guid Clientfeelingnameid { get; set; }
        public Guid Clientid { get; set; }
        public Guid Feelingid { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual Entity Feeling { get; set; } = null!;
    }
}
