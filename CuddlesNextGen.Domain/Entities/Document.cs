using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class Document
    {
        public Document()
        {
            ServiceExpertDocuments = new HashSet<ServiceExpertDocument>();
            ServiceProviderDocuments = new HashSet<ServiceProviderDocument>();
            ThreadDocuments = new HashSet<ThreadDocument>();
        }

        public Guid Documentid { get; set; }
        public string Documentname { get; set; } = null!;
        public string? Documentpath { get; set; }

        public virtual ICollection<ServiceExpertDocument> ServiceExpertDocuments { get; set; }
        public virtual ICollection<ServiceProviderDocument> ServiceProviderDocuments { get; set; }
        public virtual ICollection<ThreadDocument> ThreadDocuments { get; set; }
    }
}
