using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class User
    {
        public User()
        {
            CheckInOuts = new HashSet<CheckInOut>();
            Journals = new HashSet<Journal>();
            ServiceExperts = new HashSet<ServiceExpert>();
            ThreadDocuments = new HashSet<ThreadDocument>();
            ThreadMessages = new HashSet<ThreadMessage>();
            TribeComments = new HashSet<TribeComment>();
        }

        public Guid Userid { get; set; }
        public Guid Roleid { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public string? Emailaddress { get; set; }
        public string? Mobilenumber { get; set; }
        public string? Userphotopath { get; set; }
        public bool Isactive { get; set; }

        public virtual Entity Role { get; set; } = null!;
        public virtual ICollection<CheckInOut> CheckInOuts { get; set; }
        public virtual ICollection<Journal> Journals { get; set; }
        public virtual ICollection<ServiceExpert> ServiceExperts { get; set; }
        public virtual ICollection<ThreadDocument> ThreadDocuments { get; set; }
        public virtual ICollection<ThreadMessage> ThreadMessages { get; set; }
        public virtual ICollection<TribeComment> TribeComments { get; set; }
    }
}
