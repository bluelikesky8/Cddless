using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class ClientFeelingIcon
    {
        public Guid Clientfeelingiconid { get; set; }
        public Guid Clientid { get; set; }
        public Guid Feelingiconid { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual Entity Clientfeelingicon { get; set; } = null!;
    }
}
