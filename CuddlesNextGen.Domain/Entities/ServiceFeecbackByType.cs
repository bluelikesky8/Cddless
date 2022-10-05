using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class ServiceFeecbackByType
    {
        public Guid Servicefeedbackbytypeid { get; set; }
        public Guid Servicefeedbackid { get; set; }
        public Guid Feedbacktypeid { get; set; }
        public byte Rating { get; set; }
        public string? Feedbacktext { get; set; }
        public DateTime? Feedbackdatetime { get; set; }

        public virtual Entity Feedbacktype { get; set; } = null!;
        public virtual ServiceFeedback Servicefeedback { get; set; } = null!;
    }
}
