using System;
using System.Collections.Generic;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class Entity
    {
        public Entity()
        {
            BookingSlots = new HashSet<BookingSlot>();
            Bookings = new HashSet<Booking>();
            ClientBeliefs = new HashSet<Client>();
            ClientExercisefrequencies = new HashSet<Client>();
            ClientFamilyrelations = new HashSet<Client>();
            ClientFeelingFeedbacks = new HashSet<ClientFeelingFeedback>();
            ClientFeelingNames = new HashSet<ClientFeelingName>();
            ClientFinancialstatuses = new HashSet<Client>();
            ClientPreferredlanguages = new HashSet<Client>();
            ClientRelationshipstatuses = new HashSet<Client>();
            ClientSessionfors = new HashSet<Client>();
            ClientSleepingpatterns = new HashSet<Client>();
            ClientWorkstudies = new HashSet<Client>();
            MemberAddressCountries = new HashSet<MemberAddress>();
            MemberAddressStates = new HashSet<MemberAddress>();
            MemberPayments = new HashSet<MemberPayment>();
            ServiceExpertDetailBeliefs = new HashSet<ServiceExpertDetail>();
            ServiceExpertDetailDesignations = new HashSet<ServiceExpertDetail>();
            ServiceExpertDetailDurationofservices = new HashSet<ServiceExpertDetail>();
            ServiceExpertDetailEducations = new HashSet<ServiceExpertDetail>();
            ServiceExpertDetailPreferredlanguages = new HashSet<ServiceExpertDetail>();
            ServiceExpertDetailSalulations = new HashSet<ServiceExpertDetail>();
            ServiceFeecbackByTypes = new HashSet<ServiceFeecbackByType>();
            ServiceProviderAddressCountries = new HashSet<ServiceProviderAddress>();
            ServiceProviderAddressStates = new HashSet<ServiceProviderAddress>();
            ServiceProviderPayments = new HashSet<ServiceProviderPayment>();
            Users = new HashSet<User>();
        }

        public Guid Entityid { get; set; }
        public string Entityname { get; set; } = null!;
        public byte Entitytype { get; set; }
        public Guid? Parententityid { get; set; }

        public virtual ClientFeelingIcon ClientFeelingIcon { get; set; } = null!;
        public virtual ICollection<BookingSlot> BookingSlots { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Client> ClientBeliefs { get; set; }
        public virtual ICollection<Client> ClientExercisefrequencies { get; set; }
        public virtual ICollection<Client> ClientFamilyrelations { get; set; }
        public virtual ICollection<ClientFeelingFeedback> ClientFeelingFeedbacks { get; set; }
        public virtual ICollection<ClientFeelingName> ClientFeelingNames { get; set; }
        public virtual ICollection<Client> ClientFinancialstatuses { get; set; }
        public virtual ICollection<Client> ClientPreferredlanguages { get; set; }
        public virtual ICollection<Client> ClientRelationshipstatuses { get; set; }
        public virtual ICollection<Client> ClientSessionfors { get; set; }
        public virtual ICollection<Client> ClientSleepingpatterns { get; set; }
        public virtual ICollection<Client> ClientWorkstudies { get; set; }
        public virtual ICollection<MemberAddress> MemberAddressCountries { get; set; }
        public virtual ICollection<MemberAddress> MemberAddressStates { get; set; }
        public virtual ICollection<MemberPayment> MemberPayments { get; set; }
        public virtual ICollection<ServiceExpertDetail> ServiceExpertDetailBeliefs { get; set; }
        public virtual ICollection<ServiceExpertDetail> ServiceExpertDetailDesignations { get; set; }
        public virtual ICollection<ServiceExpertDetail> ServiceExpertDetailDurationofservices { get; set; }
        public virtual ICollection<ServiceExpertDetail> ServiceExpertDetailEducations { get; set; }
        public virtual ICollection<ServiceExpertDetail> ServiceExpertDetailPreferredlanguages { get; set; }
        public virtual ICollection<ServiceExpertDetail> ServiceExpertDetailSalulations { get; set; }
        public virtual ICollection<ServiceFeecbackByType> ServiceFeecbackByTypes { get; set; }
        public virtual ICollection<ServiceProviderAddress> ServiceProviderAddressCountries { get; set; }
        public virtual ICollection<ServiceProviderAddress> ServiceProviderAddressStates { get; set; }
        public virtual ICollection<ServiceProviderPayment> ServiceProviderPayments { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
