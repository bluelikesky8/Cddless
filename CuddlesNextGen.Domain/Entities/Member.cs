using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class Member
    {
        public Member()
        {
            Bookings = new HashSet<Booking>();
            Clients = new HashSet<Client>();
            MemberAddresses = new HashSet<MemberAddress>();
            MemberPaymentInfos = new HashSet<MemberPaymentInfo>();
            ServiceProviderExpertNotes = new HashSet<ServiceProviderExpertNote>();
            Threads = new HashSet<Thread>();
        }

        public Guid Memberid { get; set; }
        public Guid Userid { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public string Gender { get; set; } = null!;
        public bool Isactive { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<MemberAddress> MemberAddresses { get; set; }
        public virtual ICollection<MemberPaymentInfo> MemberPaymentInfos { get; set; }
        public virtual ICollection<ServiceProviderExpertNote> ServiceProviderExpertNotes { get; set; }
        public virtual ICollection<Thread> Threads { get; set; }
    }
}
