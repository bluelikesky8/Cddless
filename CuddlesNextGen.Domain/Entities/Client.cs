using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class Client
    {
        public Client()
        {
            ClientFeelingFeedbacks = new HashSet<ClientFeelingFeedback>();
            ClientFeelingIcons = new HashSet<ClientFeelingIcon>();
            ClientFeelingNames = new HashSet<ClientFeelingName>();
            ClientSafetyPlans = new HashSet<ClientSafetyPlan>();
        }

        public Guid Clientid { get; set; }
        public Guid Memberid { get; set; }
        public Guid? Beliefid { get; set; }
        public Guid? Preferredlanguageid { get; set; }
        public Guid? Sleepingpatternid { get; set; }
        public bool Takingmedicine { get; set; }
        public Guid? Workstudyid { get; set; }
        public string? Workstudyothers { get; set; }
        public Guid? Relationshipstatusid { get; set; }
        public Guid? Familyrelationid { get; set; }
        public Guid? Financialstatusid { get; set; }
        public Guid? Exercisefrequencyid { get; set; }
        public string? Moreinfo { get; set; }
        public Guid? Sessionforid { get; set; }

        public virtual Entity? Belief { get; set; }
        public virtual Entity? Exercisefrequency { get; set; }
        public virtual Entity? Familyrelation { get; set; }
        public virtual Entity? Financialstatus { get; set; }
        public virtual Member Member { get; set; } = null!;
        public virtual Entity? Preferredlanguage { get; set; }
        public virtual Entity? Relationshipstatus { get; set; }
        public virtual Entity? Sessionfor { get; set; }
        public virtual Entity? Sleepingpattern { get; set; }
        public virtual Entity? Workstudy { get; set; }
        public virtual ICollection<ClientFeelingFeedback> ClientFeelingFeedbacks { get; set; }
        public virtual ICollection<ClientFeelingIcon> ClientFeelingIcons { get; set; }
        public virtual ICollection<ClientFeelingName> ClientFeelingNames { get; set; }
        public virtual ICollection<ClientSafetyPlan> ClientSafetyPlans { get; set; }
    }
}
