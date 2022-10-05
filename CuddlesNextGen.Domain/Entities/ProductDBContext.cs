using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CuddlesNextGen.Domain.Entities
{
    public partial class ProductDBContext : DbContext
    {
        public ProductDBContext()
        {
        }

        public ProductDBContext(DbContextOptions<ProductDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Batch> Batches { get; set; } = null!;
        public virtual DbSet<BatchSlot> BatchSlots { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<BookingSlot> BookingSlots { get; set; } = null!;
        public virtual DbSet<BookingSlotServiceInfo> BookingSlotServiceInfos { get; set; } = null!;
        public virtual DbSet<CheckInOut> CheckInOuts { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<ClientFeelingFeedback> ClientFeelingFeedbacks { get; set; } = null!;
        public virtual DbSet<ClientFeelingIcon> ClientFeelingIcons { get; set; } = null!;
        public virtual DbSet<ClientFeelingName> ClientFeelingNames { get; set; } = null!;
        public virtual DbSet<ClientSafetyPlan> ClientSafetyPlans { get; set; } = null!;
        public virtual DbSet<Document> Documents { get; set; } = null!;
        public virtual DbSet<Entity> Entities { get; set; } = null!;
        public virtual DbSet<Journal> Journals { get; set; } = null!;
        public virtual DbSet<Member> Members { get; set; } = null!;
        public virtual DbSet<MemberAddress> MemberAddresses { get; set; } = null!;
        public virtual DbSet<MemberInvoice> MemberInvoices { get; set; } = null!;
        public virtual DbSet<MemberPayment> MemberPayments { get; set; } = null!;
        public virtual DbSet<MemberPaymentInfo> MemberPaymentInfos { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<ServiceCategory> ServiceCategories { get; set; } = null!;
        public virtual DbSet<ServiceExpert> ServiceExperts { get; set; } = null!;
        public virtual DbSet<ServiceExpertDetail> ServiceExpertDetails { get; set; } = null!;
        public virtual DbSet<ServiceExpertDocument> ServiceExpertDocuments { get; set; } = null!;
        public virtual DbSet<ServiceExpertService> ServiceExpertServices { get; set; } = null!;
        public virtual DbSet<ServiceFeecbackByType> ServiceFeecbackByTypes { get; set; } = null!;
        public virtual DbSet<ServiceFeedback> ServiceFeedbacks { get; set; } = null!;
        public virtual DbSet<ServiceProvider> ServiceProviders { get; set; } = null!;
        public virtual DbSet<ServiceProviderAddress> ServiceProviderAddresses { get; set; } = null!;
        public virtual DbSet<ServiceProviderDocument> ServiceProviderDocuments { get; set; } = null!;
        public virtual DbSet<ServiceProviderExpert> ServiceProviderExperts { get; set; } = null!;
        public virtual DbSet<ServiceProviderExpertNote> ServiceProviderExpertNotes { get; set; } = null!;
        public virtual DbSet<ServiceProviderExpertService> ServiceProviderExpertServices { get; set; } = null!;
        public virtual DbSet<ServiceProviderInvoice> ServiceProviderInvoices { get; set; } = null!;
        public virtual DbSet<ServiceProviderPayment> ServiceProviderPayments { get; set; } = null!;
        public virtual DbSet<ServiceProviderPaymentInfo> ServiceProviderPaymentInfos { get; set; } = null!;
        public virtual DbSet<ServiceProviderService> ServiceProviderServices { get; set; } = null!;
        public virtual DbSet<ServiceRequiredDocument> ServiceRequiredDocuments { get; set; } = null!;
        public virtual DbSet<SubscriptionPackage> SubscriptionPackages { get; set; } = null!;
        public virtual DbSet<SubscriptionPackageDetail> SubscriptionPackageDetails { get; set; } = null!;
        public virtual DbSet<SubscriptionPackageDetailMapping> SubscriptionPackageDetailMappings { get; set; } = null!;
        public virtual DbSet<Thread> Threads { get; set; } = null!;
        public virtual DbSet<ThreadDocument> ThreadDocuments { get; set; } = null!;
        public virtual DbSet<ThreadMessage> ThreadMessages { get; set; } = null!;
        public virtual DbSet<Tribe> Tribes { get; set; } = null!;
        public virtual DbSet<TribeComment> TribeComments { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-QPD0HAI\\MSSQLSERVER01;Database=ProductDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_CI_AS");

            modelBuilder.Entity<Batch>(entity =>
            {
                entity.ToTable("Batch");

                entity.Property(e => e.Batchid)
                    .ValueGeneratedNever()
                    .HasColumnName("batchid");

                entity.Property(e => e.Batchavailablecount).HasColumnName("batchavailablecount");

                entity.Property(e => e.Batchmaximumcount).HasColumnName("batchmaximumcount");

                entity.Property(e => e.Batchname)
                    .HasMaxLength(200)
                    .HasColumnName("batchname");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("enddate");

                entity.Property(e => e.Serviceproviderexpertserviceid).HasColumnName("serviceproviderexpertserviceid");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("startdate");

                entity.HasOne(d => d.Serviceproviderexpertservice)
                    .WithMany(p => p.Batches)
                    .HasForeignKey(d => d.Serviceproviderexpertserviceid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Batch_ServiceProviderExpertService");
            });

            modelBuilder.Entity<BatchSlot>(entity =>
            {
                entity.ToTable("BatchSlot");

                entity.Property(e => e.Batchslotid)
                    .ValueGeneratedNever()
                    .HasColumnName("batchslotid");

                entity.Property(e => e.Batchid).HasColumnName("batchid");

                entity.Property(e => e.Batchslotavailablecount).HasColumnName("batchslotavailablecount");

                entity.Property(e => e.Batchslotmaximumcount).HasColumnName("batchslotmaximumcount");

                entity.Property(e => e.Slotdate)
                    .HasColumnType("datetime")
                    .HasColumnName("slotdate");

                entity.Property(e => e.Slotfrom).HasColumnName("slotfrom");

                entity.Property(e => e.Slotto).HasColumnName("slotto");

                entity.HasOne(d => d.Batch)
                    .WithMany(p => p.BatchSlots)
                    .HasForeignKey(d => d.Batchid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BatchSlot_Batch");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.Bookingid)
                    .ValueGeneratedNever()
                    .HasColumnName("bookingid");

                entity.Property(e => e.Bookingdatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("bookingdatetime");

                entity.Property(e => e.Bookingnumber)
                    .HasMaxLength(200)
                    .HasColumnName("bookingnumber");

                entity.Property(e => e.Isrecurring).HasColumnName("isrecurring");

                entity.Property(e => e.Memberid).HasColumnName("memberid");

                entity.Property(e => e.Servicemodeid).HasColumnName("servicemodeid");

                entity.Property(e => e.Subscriptionpackageid).HasColumnName("subscriptionpackageid");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.Memberid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Member");

                entity.HasOne(d => d.Servicemode)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.Servicemodeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Entity");
            });

            modelBuilder.Entity<BookingSlot>(entity =>
            {
                entity.ToTable("BookingSlot");

                entity.Property(e => e.Bookingslotid)
                    .ValueGeneratedNever()
                    .HasColumnName("bookingslotid");

                entity.Property(e => e.Batchslotid).HasColumnName("batchslotid");

                entity.Property(e => e.Bookingid).HasColumnName("bookingid");

                entity.Property(e => e.Bookingslotstatusid).HasColumnName("bookingslotstatusid");

                entity.Property(e => e.Servicecostbyprovider)
                    .HasColumnType("money")
                    .HasColumnName("servicecostbyprovider");

                entity.Property(e => e.Servicecostformember)
                    .HasColumnType("money")
                    .HasColumnName("servicecostformember");

                entity.HasOne(d => d.Batchslot)
                    .WithMany(p => p.BookingSlots)
                    .HasForeignKey(d => d.Batchslotid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookingSlot_BatchSlot");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingSlots)
                    .HasForeignKey(d => d.Bookingid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookingSlot_Booking");

                entity.HasOne(d => d.Bookingslotstatus)
                    .WithMany(p => p.BookingSlots)
                    .HasForeignKey(d => d.Bookingslotstatusid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookingSlot_Entity");
            });

            modelBuilder.Entity<BookingSlotServiceInfo>(entity =>
            {
                entity.ToTable("BookingSlotServiceInfo");

                entity.Property(e => e.Bookingslotserviceinfoid)
                    .ValueGeneratedNever()
                    .HasColumnName("bookingslotserviceinfoid");

                entity.Property(e => e.Bookingslotid).HasColumnName("bookingslotid");

                entity.Property(e => e.Diagnosis)
                    .HasMaxLength(1000)
                    .HasColumnName("diagnosis");

                entity.Property(e => e.Isdiagnosedbefore).HasColumnName("isdiagnosedbefore");

                entity.Property(e => e.Takingmedicine).HasColumnName("takingmedicine");

                entity.HasOne(d => d.Bookingslot)
                    .WithMany(p => p.BookingSlotServiceInfos)
                    .HasForeignKey(d => d.Bookingslotid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookingSlotServiceInfo_BookingSlot");
            });

            modelBuilder.Entity<CheckInOut>(entity =>
            {
                entity.ToTable("CheckInOut");

                entity.Property(e => e.Checkinoutid)
                    .ValueGeneratedNever()
                    .HasColumnName("checkinoutid");

                entity.Property(e => e.Bookingslotid).HasColumnName("bookingslotid");

                entity.Property(e => e.Checkindatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("checkindatetime");

                entity.Property(e => e.Checkoutdatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("checkoutdatetime");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Bookingslot)
                    .WithMany(p => p.CheckInOuts)
                    .HasForeignKey(d => d.Bookingslotid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CheckInOut_BookingSlot");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CheckInOuts)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CheckInOut_User");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Clientid)
                    .ValueGeneratedNever()
                    .HasColumnName("clientid");

                entity.Property(e => e.Beliefid).HasColumnName("beliefid");

                entity.Property(e => e.Exercisefrequencyid).HasColumnName("exercisefrequencyid");

                entity.Property(e => e.Familyrelationid).HasColumnName("familyrelationid");

                entity.Property(e => e.Financialstatusid).HasColumnName("financialstatusid");

                entity.Property(e => e.Memberid).HasColumnName("memberid");

                entity.Property(e => e.Moreinfo)
                    .HasMaxLength(4000)
                    .HasColumnName("moreinfo");

                entity.Property(e => e.Preferredlanguageid).HasColumnName("preferredlanguageid");

                entity.Property(e => e.Relationshipstatusid).HasColumnName("relationshipstatusid");

                entity.Property(e => e.Sessionforid).HasColumnName("sessionforid");

                entity.Property(e => e.Sleepingpatternid).HasColumnName("sleepingpatternid");

                entity.Property(e => e.Takingmedicine).HasColumnName("takingmedicine");

                entity.Property(e => e.Workstudyid).HasColumnName("workstudyid");

                entity.Property(e => e.Workstudyothers)
                    .HasMaxLength(200)
                    .HasColumnName("workstudyothers");

                entity.HasOne(d => d.Belief)
                    .WithMany(p => p.ClientBeliefs)
                    .HasForeignKey(d => d.Beliefid)
                    .HasConstraintName("FK_Client_Entity");

                entity.HasOne(d => d.Exercisefrequency)
                    .WithMany(p => p.ClientExercisefrequencies)
                    .HasForeignKey(d => d.Exercisefrequencyid)
                    .HasConstraintName("FK_Client_Entity1");

                entity.HasOne(d => d.Familyrelation)
                    .WithMany(p => p.ClientFamilyrelations)
                    .HasForeignKey(d => d.Familyrelationid)
                    .HasConstraintName("FK_Client_Entity2");

                entity.HasOne(d => d.Financialstatus)
                    .WithMany(p => p.ClientFinancialstatuses)
                    .HasForeignKey(d => d.Financialstatusid)
                    .HasConstraintName("FK_Client_Entity3");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.Memberid)
                    .HasConstraintName("FK_Client_Member");

                entity.HasOne(d => d.Preferredlanguage)
                    .WithMany(p => p.ClientPreferredlanguages)
                    .HasForeignKey(d => d.Preferredlanguageid)
                    .HasConstraintName("FK_Client_Entity4");

                entity.HasOne(d => d.Relationshipstatus)
                    .WithMany(p => p.ClientRelationshipstatuses)
                    .HasForeignKey(d => d.Relationshipstatusid)
                    .HasConstraintName("FK_Client_Entity5");

                entity.HasOne(d => d.Sessionfor)
                    .WithMany(p => p.ClientSessionfors)
                    .HasForeignKey(d => d.Sessionforid)
                    .HasConstraintName("FK_Client_Entity8");

                entity.HasOne(d => d.Sleepingpattern)
                    .WithMany(p => p.ClientSleepingpatterns)
                    .HasForeignKey(d => d.Sleepingpatternid)
                    .HasConstraintName("FK_Client_Entity6");

                entity.HasOne(d => d.Workstudy)
                    .WithMany(p => p.ClientWorkstudies)
                    .HasForeignKey(d => d.Workstudyid)
                    .HasConstraintName("FK_Client_Entity7");
            });

            modelBuilder.Entity<ClientFeelingFeedback>(entity =>
            {
                entity.ToTable("ClientFeelingFeedback");

                entity.Property(e => e.Clientfeelingfeedbackid)
                    .ValueGeneratedNever()
                    .HasColumnName("clientfeelingfeedbackid");

                entity.Property(e => e.Bookingslotid).HasColumnName("bookingslotid");

                entity.Property(e => e.Clientid).HasColumnName("clientid");

                entity.Property(e => e.Feelingiconid).HasColumnName("feelingiconid");

                entity.Property(e => e.Preorpost)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("preorpost")
                    .IsFixedLength();

                entity.HasOne(d => d.Bookingslot)
                    .WithMany(p => p.ClientFeelingFeedbacks)
                    .HasForeignKey(d => d.Bookingslotid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CareTakerFeelingFeedback_BookingSlot");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientFeelingFeedbacks)
                    .HasForeignKey(d => d.Clientid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientFeelingFeedback_Client");

                entity.HasOne(d => d.Feelingicon)
                    .WithMany(p => p.ClientFeelingFeedbacks)
                    .HasForeignKey(d => d.Feelingiconid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CareTakerFeelingFeedback_Entity");
            });

            modelBuilder.Entity<ClientFeelingIcon>(entity =>
            {
                entity.ToTable("ClientFeelingIcon");

                entity.Property(e => e.Clientfeelingiconid)
                    .ValueGeneratedNever()
                    .HasColumnName("clientfeelingiconid");

                entity.Property(e => e.Clientid).HasColumnName("clientid");

                entity.Property(e => e.Feelingiconid).HasColumnName("feelingiconid");

                entity.HasOne(d => d.Clientfeelingicon)
                    .WithOne(p => p.ClientFeelingIcon)
                    .HasForeignKey<ClientFeelingIcon>(d => d.Clientfeelingiconid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CareTakerFeelingIcon_Entity");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientFeelingIcons)
                    .HasForeignKey(d => d.Clientid)
                    .HasConstraintName("FK_ClientFeelingIcon_Client");
            });

            modelBuilder.Entity<ClientFeelingName>(entity =>
            {
                entity.ToTable("ClientFeelingName");

                entity.Property(e => e.Clientfeelingnameid)
                    .ValueGeneratedNever()
                    .HasColumnName("clientfeelingnameid");

                entity.Property(e => e.Clientid).HasColumnName("clientid");

                entity.Property(e => e.Feelingid).HasColumnName("feelingid");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientFeelingNames)
                    .HasForeignKey(d => d.Clientid)
                    .HasConstraintName("FK_ClientFeelingName_Client");

                entity.HasOne(d => d.Feeling)
                    .WithMany(p => p.ClientFeelingNames)
                    .HasForeignKey(d => d.Feelingid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CareTakerFeelingName_Entity");
            });

            modelBuilder.Entity<ClientSafetyPlan>(entity =>
            {
                entity.ToTable("ClientSafetyPlan");

                entity.Property(e => e.Clientsafetyplanid)
                    .ValueGeneratedNever()
                    .HasColumnName("clientsafetyplanid");

                entity.Property(e => e.Callfamily)
                    .HasMaxLength(1000)
                    .HasColumnName("callfamily");

                entity.Property(e => e.Callfriends)
                    .HasMaxLength(1000)
                    .HasColumnName("callfriends");

                entity.Property(e => e.Callothers)
                    .HasMaxLength(1000)
                    .HasColumnName("callothers");

                entity.Property(e => e.Clientid).HasColumnName("clientid");

                entity.Property(e => e.Needprofessionalsupport)
                    .HasMaxLength(4000)
                    .HasColumnName("needprofessionalsupport");

                entity.Property(e => e.Referwhen)
                    .HasMaxLength(4000)
                    .HasColumnName("referwhen");

                entity.Property(e => e.Thingstocalm)
                    .HasMaxLength(4000)
                    .HasColumnName("thingstocalm");

                entity.Property(e => e.Thingstomakeenvsafe)
                    .HasMaxLength(4000)
                    .HasColumnName("thingstomakeenvsafe");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientSafetyPlans)
                    .HasForeignKey(d => d.Clientid)
                    .HasConstraintName("FK_ClientSafetyPlan_Client");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("Document");

                entity.Property(e => e.Documentid)
                    .ValueGeneratedNever()
                    .HasColumnName("documentid");

                entity.Property(e => e.Documentname)
                    .HasMaxLength(200)
                    .HasColumnName("documentname");

                entity.Property(e => e.Documentpath)
                    .HasMaxLength(1000)
                    .HasColumnName("documentpath");
            });

            modelBuilder.Entity<Entity>(entity =>
            {
                entity.ToTable("Entity");

                entity.Property(e => e.Entityid)
                    .ValueGeneratedNever()
                    .HasColumnName("entityid");

                entity.Property(e => e.Entityname)
                    .HasMaxLength(200)
                    .HasColumnName("entityname");

                entity.Property(e => e.Entitytype).HasColumnName("entitytype");

                entity.Property(e => e.Parententityid).HasColumnName("parententityid");
            });

            modelBuilder.Entity<Journal>(entity =>
            {
                entity.ToTable("Journal");

                entity.Property(e => e.Journalid)
                    .ValueGeneratedNever()
                    .HasColumnName("journalid");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Journalphotopath)
                    .HasMaxLength(1000)
                    .HasColumnName("journalphotopath");

                entity.Property(e => e.Journaltags)
                    .HasMaxLength(1000)
                    .HasColumnName("journaltags");

                entity.Property(e => e.Journaltext)
                    .HasColumnType("ntext")
                    .HasColumnName("journaltext");

                entity.Property(e => e.Journaltitle)
                    .HasMaxLength(400)
                    .HasColumnName("journaltitle");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Journals)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Journal_User");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("Member");

                entity.Property(e => e.Memberid)
                    .ValueGeneratedNever()
                    .HasColumnName("memberid");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnType("datetime")
                    .HasColumnName("dateofbirth");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("gender")
                    .IsFixedLength();

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            modelBuilder.Entity<MemberAddress>(entity =>
            {
                entity.ToTable("MemberAddress");

                entity.Property(e => e.Memberaddressid)
                    .ValueGeneratedNever()
                    .HasColumnName("memberaddressid");

                entity.Property(e => e.Address)
                    .HasMaxLength(2000)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .HasColumnName("city");

                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.Memberid).HasColumnName("memberid");

                entity.Property(e => e.Stateid).HasColumnName("stateid");

                entity.Property(e => e.Zipcode)
                    .HasMaxLength(50)
                    .HasColumnName("zipcode");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.MemberAddressCountries)
                    .HasForeignKey(d => d.Countryid)
                    .HasConstraintName("FK_MemberAddress_MemberAddress1");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MemberAddresses)
                    .HasForeignKey(d => d.Memberid)
                    .HasConstraintName("FK_MemberAddress_Member");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.MemberAddressStates)
                    .HasForeignKey(d => d.Stateid)
                    .HasConstraintName("FK_MemberAddress_MemberAddress2");
            });

            modelBuilder.Entity<MemberInvoice>(entity =>
            {
                entity.ToTable("MemberInvoice");

                entity.Property(e => e.Memberinvoiceid)
                    .ValueGeneratedNever()
                    .HasColumnName("memberinvoiceid");

                entity.Property(e => e.Bookingid).HasColumnName("bookingid");

                entity.Property(e => e.Invoiceamount)
                    .HasColumnType("money")
                    .HasColumnName("invoiceamount");

                entity.Property(e => e.Invoicedatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("invoicedatetime");

                entity.Property(e => e.Invoicenumber)
                    .HasMaxLength(100)
                    .HasColumnName("invoicenumber");

                entity.Property(e => e.Ispaid).HasColumnName("ispaid");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.MemberInvoices)
                    .HasForeignKey(d => d.Bookingid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberInvoice_Booking");
            });

            modelBuilder.Entity<MemberPayment>(entity =>
            {
                entity.ToTable("MemberPayment");

                entity.Property(e => e.Memberpaymentid)
                    .ValueGeneratedNever()
                    .HasColumnName("memberpaymentid");

                entity.Property(e => e.Memberinvoiceid).HasColumnName("memberinvoiceid");

                entity.Property(e => e.Paymentamount)
                    .HasColumnType("money")
                    .HasColumnName("paymentamount");

                entity.Property(e => e.Paymentdatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("paymentdatetime");

                entity.Property(e => e.Paymentmodeid).HasColumnName("paymentmodeid");

                entity.HasOne(d => d.Memberinvoice)
                    .WithMany(p => p.MemberPayments)
                    .HasForeignKey(d => d.Memberinvoiceid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberPayment_MemberInvoice");

                entity.HasOne(d => d.Paymentmode)
                    .WithMany(p => p.MemberPayments)
                    .HasForeignKey(d => d.Paymentmodeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberPayment_Entity");
            });

            modelBuilder.Entity<MemberPaymentInfo>(entity =>
            {
                entity.ToTable("MemberPaymentInfo");

                entity.Property(e => e.Memberpaymentinfoid)
                    .ValueGeneratedNever()
                    .HasColumnName("memberpaymentinfoid");

                entity.Property(e => e.Creditcardnumber)
                    .HasMaxLength(20)
                    .HasColumnName("creditcardnumber");

                entity.Property(e => e.Expirydate)
                    .HasColumnType("datetime")
                    .HasColumnName("expirydate");

                entity.Property(e => e.Memberid).HasColumnName("memberid");

                entity.Property(e => e.Nameoncard)
                    .HasMaxLength(200)
                    .HasColumnName("nameoncard");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MemberPaymentInfos)
                    .HasForeignKey(d => d.Memberid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberPaymentInfo_Member");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.Serviceid)
                    .ValueGeneratedNever()
                    .HasColumnName("serviceid");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Servicecategoryid).HasColumnName("servicecategoryid");

                entity.Property(e => e.Serviceimage)
                    .HasColumnType("image")
                    .HasColumnName("serviceimage");

                entity.Property(e => e.Servicename)
                    .HasMaxLength(100)
                    .HasColumnName("servicename");

                entity.HasOne(d => d.Servicecategory)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.Servicecategoryid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Service_ServiceCategory");
            });

            modelBuilder.Entity<ServiceCategory>(entity =>
            {
                entity.ToTable("ServiceCategory");

                entity.Property(e => e.Servicecategoryid)
                    .ValueGeneratedNever()
                    .HasColumnName("servicecategoryid");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Parentservicecategoryid).HasColumnName("parentservicecategoryid");

                entity.Property(e => e.Servicecategoryimage)
                    .HasColumnType("image")
                    .HasColumnName("servicecategoryimage");

                entity.Property(e => e.Servicecategoryname)
                    .HasMaxLength(100)
                    .HasColumnName("servicecategoryname");

                entity.HasOne(d => d.Parentservicecategory)
                    .WithMany(p => p.InverseParentservicecategory)
                    .HasForeignKey(d => d.Parentservicecategoryid)
                    .HasConstraintName("FK_ServiceCategory_ServiceCategory");
            });

            modelBuilder.Entity<ServiceExpert>(entity =>
            {
                entity.ToTable("ServiceExpert");

                entity.Property(e => e.Serviceexpertid)
                    .ValueGeneratedNever()
                    .HasColumnName("serviceexpertid");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnType("datetime")
                    .HasColumnName("dateofbirth");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("gender")
                    .IsFixedLength();

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ServiceExperts)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceExpert_User");
            });

            modelBuilder.Entity<ServiceExpertDetail>(entity =>
            {
                entity.ToTable("ServiceExpertDetail");

                entity.Property(e => e.Serviceexpertdetailid)
                    .ValueGeneratedNever()
                    .HasColumnName("serviceexpertdetailid");

                entity.Property(e => e.Beliefid).HasColumnName("beliefid");

                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.Designationid).HasColumnName("designationid");

                entity.Property(e => e.Durationofserviceid).HasColumnName("durationofserviceid");

                entity.Property(e => e.Educationid).HasColumnName("educationid");

                entity.Property(e => e.Preferredlanguageid).HasColumnName("preferredlanguageid");

                entity.Property(e => e.Salulationid).HasColumnName("salulationid");

                entity.Property(e => e.Serviceexpertid).HasColumnName("serviceexpertid");

                entity.Property(e => e.Specializaion)
                    .HasMaxLength(1000)
                    .HasColumnName("specializaion");

                entity.HasOne(d => d.Belief)
                    .WithMany(p => p.ServiceExpertDetailBeliefs)
                    .HasForeignKey(d => d.Beliefid)
                    .HasConstraintName("FK_ServiceExpertDetail_Entity2");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.ServiceExpertDetailDesignations)
                    .HasForeignKey(d => d.Designationid)
                    .HasConstraintName("FK_ServiceExpertDetail_Entity1");

                entity.HasOne(d => d.Durationofservice)
                    .WithMany(p => p.ServiceExpertDetailDurationofservices)
                    .HasForeignKey(d => d.Durationofserviceid)
                    .HasConstraintName("FK_ServiceExpertDetail_Entity5");

                entity.HasOne(d => d.Education)
                    .WithMany(p => p.ServiceExpertDetailEducations)
                    .HasForeignKey(d => d.Educationid)
                    .HasConstraintName("FK_ServiceExpertDetail_Entity");

                entity.HasOne(d => d.Preferredlanguage)
                    .WithMany(p => p.ServiceExpertDetailPreferredlanguages)
                    .HasForeignKey(d => d.Preferredlanguageid)
                    .HasConstraintName("FK_ServiceExpertDetail_Entity3");

                entity.HasOne(d => d.Salulation)
                    .WithMany(p => p.ServiceExpertDetailSalulations)
                    .HasForeignKey(d => d.Salulationid)
                    .HasConstraintName("FK_ServiceExpertDetail_Entity4");

                entity.HasOne(d => d.Serviceexpert)
                    .WithMany(p => p.ServiceExpertDetails)
                    .HasForeignKey(d => d.Serviceexpertid)
                    .HasConstraintName("FK_ServiceExpertDetail_ServiceExpert");
            });

            modelBuilder.Entity<ServiceExpertDocument>(entity =>
            {
                entity.ToTable("ServiceExpertDocument");

                entity.Property(e => e.Serviceexpertdocumentid)
                    .ValueGeneratedNever()
                    .HasColumnName("serviceexpertdocumentid");

                entity.Property(e => e.Documentid).HasColumnName("documentid");

                entity.Property(e => e.Serviceexpertid).HasColumnName("serviceexpertid");

                entity.Property(e => e.Servicerequireddocumentid).HasColumnName("servicerequireddocumentid");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.ServiceExpertDocuments)
                    .HasForeignKey(d => d.Documentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceExpertDocument_Document");

                entity.HasOne(d => d.Serviceexpert)
                    .WithMany(p => p.ServiceExpertDocuments)
                    .HasForeignKey(d => d.Serviceexpertid)
                    .HasConstraintName("FK_ServiceExpertDocument_ServiceExpert");

                entity.HasOne(d => d.Servicerequireddocument)
                    .WithMany(p => p.ServiceExpertDocuments)
                    .HasForeignKey(d => d.Servicerequireddocumentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceExpertDocument_ServiceRequiredDocument");
            });

            modelBuilder.Entity<ServiceExpertService>(entity =>
            {
                entity.ToTable("ServiceExpertService");

                entity.Property(e => e.Serviceexpertserviceid)
                    .ValueGeneratedNever()
                    .HasColumnName("serviceexpertserviceid");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Serviceexpertid).HasColumnName("serviceexpertid");

                entity.Property(e => e.Serviceid).HasColumnName("serviceid");

                entity.HasOne(d => d.Serviceexpert)
                    .WithMany(p => p.ServiceExpertServices)
                    .HasForeignKey(d => d.Serviceexpertid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceExpertService_ServiceExpert");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServiceExpertServices)
                    .HasForeignKey(d => d.Serviceid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceExpertService_Service");
            });

            modelBuilder.Entity<ServiceFeecbackByType>(entity =>
            {
                entity.HasKey(e => e.Servicefeedbackbytypeid);

                entity.ToTable("ServiceFeecbackByType");

                entity.Property(e => e.Servicefeedbackbytypeid)
                    .ValueGeneratedNever()
                    .HasColumnName("servicefeedbackbytypeid");

                entity.Property(e => e.Feedbackdatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("feedbackdatetime");

                entity.Property(e => e.Feedbacktext)
                    .HasMaxLength(1000)
                    .HasColumnName("feedbacktext");

                entity.Property(e => e.Feedbacktypeid).HasColumnName("feedbacktypeid");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Servicefeedbackid).HasColumnName("servicefeedbackid");

                entity.HasOne(d => d.Feedbacktype)
                    .WithMany(p => p.ServiceFeecbackByTypes)
                    .HasForeignKey(d => d.Feedbacktypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceFeecbackByType_Entity");

                entity.HasOne(d => d.Servicefeedback)
                    .WithMany(p => p.ServiceFeecbackByTypes)
                    .HasForeignKey(d => d.Servicefeedbackid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceFeecbackByType_ServiceFeedback");
            });

            modelBuilder.Entity<ServiceFeedback>(entity =>
            {
                entity.ToTable("ServiceFeedback");

                entity.Property(e => e.Servicefeedbackid)
                    .ValueGeneratedNever()
                    .HasColumnName("servicefeedbackid");

                entity.Property(e => e.Bookingslotid).HasColumnName("bookingslotid");

                entity.Property(e => e.Feedbackdatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("feedbackdatetime");

                entity.Property(e => e.Feedbacktext)
                    .HasMaxLength(2000)
                    .HasColumnName("feedbacktext");

                entity.Property(e => e.Overallrating).HasColumnName("overallrating");

                entity.HasOne(d => d.Bookingslot)
                    .WithMany(p => p.ServiceFeedbacks)
                    .HasForeignKey(d => d.Bookingslotid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceFeedback_BookingSlot");
            });

            modelBuilder.Entity<ServiceProvider>(entity =>
            {
                entity.ToTable("ServiceProvider");

                entity.Property(e => e.Serviceproviderid)
                    .ValueGeneratedNever()
                    .HasColumnName("serviceproviderid");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Serviceprovidername)
                    .HasMaxLength(200)
                    .HasColumnName("serviceprovidername");

                entity.Property(e => e.Serviceproviderphotopath)
                    .HasMaxLength(1000)
                    .HasColumnName("serviceproviderphotopath");
            });

            modelBuilder.Entity<ServiceProviderAddress>(entity =>
            {
                entity.ToTable("ServiceProviderAddress");

                entity.Property(e => e.Serviceprovideraddressid)
                    .ValueGeneratedNever()
                    .HasColumnName("serviceprovideraddressid");

                entity.Property(e => e.Address)
                    .HasMaxLength(2000)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .HasColumnName("city");

                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.Serviceproviderid).HasColumnName("serviceproviderid");

                entity.Property(e => e.Stateid).HasColumnName("stateid");

                entity.Property(e => e.Zipcode)
                    .HasMaxLength(50)
                    .HasColumnName("zipcode");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.ServiceProviderAddressCountries)
                    .HasForeignKey(d => d.Countryid)
                    .HasConstraintName("FK_ServiceProviderAddress_Entity1");

                entity.HasOne(d => d.Serviceprovider)
                    .WithMany(p => p.ServiceProviderAddresses)
                    .HasForeignKey(d => d.Serviceproviderid)
                    .HasConstraintName("FK_ServiceProviderAddress_ServiceProvider");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.ServiceProviderAddressStates)
                    .HasForeignKey(d => d.Stateid)
                    .HasConstraintName("FK_ServiceProviderAddress_Entity");
            });

            modelBuilder.Entity<ServiceProviderDocument>(entity =>
            {
                entity.ToTable("ServiceProviderDocument");

                entity.Property(e => e.Serviceproviderdocumentid)
                    .ValueGeneratedNever()
                    .HasColumnName("serviceproviderdocumentid");

                entity.Property(e => e.Documentid).HasColumnName("documentid");

                entity.Property(e => e.Serviceproviderid).HasColumnName("serviceproviderid");

                entity.Property(e => e.Servicerequireddocumentid).HasColumnName("servicerequireddocumentid");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.ServiceProviderDocuments)
                    .HasForeignKey(d => d.Documentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceProviderDocument_Document");

                entity.HasOne(d => d.Serviceprovider)
                    .WithMany(p => p.ServiceProviderDocuments)
                    .HasForeignKey(d => d.Serviceproviderid)
                    .HasConstraintName("FK_ServiceProviderDocument_ServiceProvider");

                entity.HasOne(d => d.Servicerequireddocument)
                    .WithMany(p => p.ServiceProviderDocuments)
                    .HasForeignKey(d => d.Servicerequireddocumentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceProviderDocument_ServiceRequiredDocument");
            });

            modelBuilder.Entity<ServiceProviderExpert>(entity =>
            {
                entity.ToTable("ServiceProviderExpert");

                entity.Property(e => e.Serviceproviderexpertid)
                    .ValueGeneratedNever()
                    .HasColumnName("serviceproviderexpertid");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Serviceexpertid).HasColumnName("serviceexpertid");

                entity.Property(e => e.Serviceproviderid).HasColumnName("serviceproviderid");

                entity.HasOne(d => d.Serviceexpert)
                    .WithMany(p => p.ServiceProviderExperts)
                    .HasForeignKey(d => d.Serviceexpertid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceProviderExpert_ServiceExpert");

                entity.HasOne(d => d.Serviceprovider)
                    .WithMany(p => p.ServiceProviderExperts)
                    .HasForeignKey(d => d.Serviceproviderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceProviderExpert_ServiceProvider");
            });

            modelBuilder.Entity<ServiceProviderExpertNote>(entity =>
            {
                entity.Property(e => e.Serviceproviderexpertnoteid)
                    .ValueGeneratedNever()
                    .HasColumnName("serviceproviderexpertnoteid");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Memberid).HasColumnName("memberid");

                entity.Property(e => e.Note)
                    .HasMaxLength(4000)
                    .HasColumnName("note");

                entity.Property(e => e.Notedatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("notedatetime");

                entity.Property(e => e.Serviceproviderexpertid).HasColumnName("serviceproviderexpertid");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.ServiceProviderExpertNotes)
                    .HasForeignKey(d => d.Memberid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceProviderExpertNotes_Member");

                entity.HasOne(d => d.Serviceproviderexpert)
                    .WithMany(p => p.ServiceProviderExpertNotes)
                    .HasForeignKey(d => d.Serviceproviderexpertid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceProviderExpertNotes_ServiceProviderExpert");
            });

            modelBuilder.Entity<ServiceProviderExpertService>(entity =>
            {
                entity.ToTable("ServiceProviderExpertService");

                entity.Property(e => e.Serviceproviderexpertserviceid)
                    .ValueGeneratedNever()
                    .HasColumnName("serviceproviderexpertserviceid");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Servicecostbyprovider)
                    .HasColumnType("money")
                    .HasColumnName("servicecostbyprovider");

                entity.Property(e => e.Servicecostformember)
                    .HasColumnType("money")
                    .HasColumnName("servicecostformember");

                entity.Property(e => e.Serviceduration)
                    .HasMaxLength(200)
                    .HasColumnName("serviceduration");

                entity.Property(e => e.Serviceexpertid).HasColumnName("serviceexpertid");

                entity.Property(e => e.Serviceid).HasColumnName("serviceid");

                entity.Property(e => e.Servicenoteformember)
                    .HasMaxLength(2000)
                    .HasColumnName("servicenoteformember");

                entity.Property(e => e.Serviceproviderid).HasColumnName("serviceproviderid");

                entity.HasOne(d => d.Serviceexpert)
                    .WithMany(p => p.ServiceProviderExpertServices)
                    .HasForeignKey(d => d.Serviceexpertid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceProviderExpertService_ServiceExpert");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServiceProviderExpertServices)
                    .HasForeignKey(d => d.Serviceid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceProviderExpertService_Service");

                entity.HasOne(d => d.Serviceprovider)
                    .WithMany(p => p.ServiceProviderExpertServices)
                    .HasForeignKey(d => d.Serviceproviderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceProviderExpertService_ServiceProvider");
            });

            modelBuilder.Entity<ServiceProviderInvoice>(entity =>
            {
                entity.ToTable("ServiceProviderInvoice");

                entity.Property(e => e.Serviceproviderinvoiceid)
                    .ValueGeneratedNever()
                    .HasColumnName("serviceproviderinvoiceid");

                entity.Property(e => e.Invoiceamount)
                    .HasColumnType("money")
                    .HasColumnName("invoiceamount");

                entity.Property(e => e.Invoicedatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("invoicedatetime");

                entity.Property(e => e.Invoicenumber)
                    .HasMaxLength(200)
                    .HasColumnName("invoicenumber");

                entity.Property(e => e.Ispaid).HasColumnName("ispaid");

                entity.Property(e => e.Memberinvoiceid).HasColumnName("memberinvoiceid");

                entity.Property(e => e.Serviceproviderid).HasColumnName("serviceproviderid");

                entity.HasOne(d => d.Memberinvoice)
                    .WithMany(p => p.ServiceProviderInvoices)
                    .HasForeignKey(d => d.Memberinvoiceid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceProviderInvoice_MemberInvoice");

                entity.HasOne(d => d.Serviceprovider)
                    .WithMany(p => p.ServiceProviderInvoices)
                    .HasForeignKey(d => d.Serviceproviderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceProviderInvoice_ServiceProvider");
            });

            modelBuilder.Entity<ServiceProviderPayment>(entity =>
            {
                entity.ToTable("ServiceProviderPayment");

                entity.Property(e => e.Serviceproviderpaymentid)
                    .ValueGeneratedNever()
                    .HasColumnName("serviceproviderpaymentid");

                entity.Property(e => e.Paymentamount)
                    .HasColumnType("money")
                    .HasColumnName("paymentamount");

                entity.Property(e => e.Paymentdatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("paymentdatetime");

                entity.Property(e => e.Paymentmodeid).HasColumnName("paymentmodeid");

                entity.Property(e => e.Serviceproviderinvoiceid).HasColumnName("serviceproviderinvoiceid");

                entity.HasOne(d => d.Paymentmode)
                    .WithMany(p => p.ServiceProviderPayments)
                    .HasForeignKey(d => d.Paymentmodeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceProviderPayment_Entity");

                entity.HasOne(d => d.Serviceproviderinvoice)
                    .WithMany(p => p.ServiceProviderPayments)
                    .HasForeignKey(d => d.Serviceproviderinvoiceid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceProviderPayment_ServiceProviderInvoice");
            });

            modelBuilder.Entity<ServiceProviderPaymentInfo>(entity =>
            {
                entity.ToTable("ServiceProviderPaymentInfo");

                entity.Property(e => e.Serviceproviderpaymentinfoid)
                    .ValueGeneratedNever()
                    .HasColumnName("serviceproviderpaymentinfoid");

                entity.Property(e => e.Accountnumber)
                    .HasMaxLength(50)
                    .HasColumnName("accountnumber");

                entity.Property(e => e.Bankname)
                    .HasMaxLength(200)
                    .HasColumnName("bankname");

                entity.Property(e => e.Beneficiaryname)
                    .HasMaxLength(200)
                    .HasColumnName("beneficiaryname");

                entity.Property(e => e.Ifsccode)
                    .HasMaxLength(50)
                    .HasColumnName("ifsccode");

                entity.Property(e => e.Serviceproviderid).HasColumnName("serviceproviderid");

                entity.HasOne(d => d.Serviceprovider)
                    .WithMany(p => p.ServiceProviderPaymentInfos)
                    .HasForeignKey(d => d.Serviceproviderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceProviderPaymentInfo_ServiceProvider");
            });

            modelBuilder.Entity<ServiceProviderService>(entity =>
            {
                entity.ToTable("ServiceProviderService");

                entity.Property(e => e.Serviceproviderserviceid)
                    .ValueGeneratedNever()
                    .HasColumnName("serviceproviderserviceid");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Serviceid).HasColumnName("serviceid");

                entity.Property(e => e.Serviceproviderid).HasColumnName("serviceproviderid");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServiceProviderServices)
                    .HasForeignKey(d => d.Serviceid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceProviderService_Service");

                entity.HasOne(d => d.Serviceprovider)
                    .WithMany(p => p.ServiceProviderServices)
                    .HasForeignKey(d => d.Serviceproviderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceProviderService_ServiceProvider");
            });

            modelBuilder.Entity<ServiceRequiredDocument>(entity =>
            {
                entity.ToTable("ServiceRequiredDocument");

                entity.Property(e => e.Servicerequireddocumentid)
                    .ValueGeneratedNever()
                    .HasColumnName("servicerequireddocumentid");

                entity.Property(e => e.Serviceid).HasColumnName("serviceid");

                entity.Property(e => e.Serviceproviderid).HasColumnName("serviceproviderid");

                entity.Property(e => e.Servicerequireddocumentfor)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("servicerequireddocumentfor")
                    .IsFixedLength();

                entity.Property(e => e.Servicerequireddocumentname)
                    .HasMaxLength(100)
                    .HasColumnName("servicerequireddocumentname");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServiceRequiredDocuments)
                    .HasForeignKey(d => d.Serviceid)
                    .HasConstraintName("FK_ServiceRequiredDocument_Service");

                entity.HasOne(d => d.Serviceprovider)
                    .WithMany(p => p.ServiceRequiredDocuments)
                    .HasForeignKey(d => d.Serviceproviderid)
                    .HasConstraintName("FK_ServiceRequiredDocument_ServiceProvider");
            });

            modelBuilder.Entity<SubscriptionPackage>(entity =>
            {
                entity.ToTable("SubscriptionPackage");

                entity.Property(e => e.Subscriptionpackageid)
                    .ValueGeneratedNever()
                    .HasColumnName("subscriptionpackageid");

                entity.Property(e => e.Batchid).HasColumnName("batchid");

                entity.Property(e => e.Durationdays).HasColumnName("durationdays");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Isrecurring).HasColumnName("isrecurring");

                entity.Property(e => e.Numberofjournalentries).HasColumnName("numberofjournalentries");

                entity.Property(e => e.Packageamountformember)
                    .HasColumnType("money")
                    .HasColumnName("packageamountformember");

                entity.Property(e => e.Subscriptionpackagename)
                    .HasMaxLength(200)
                    .HasColumnName("subscriptionpackagename");
            });

            modelBuilder.Entity<SubscriptionPackageDetail>(entity =>
            {
                entity.ToTable("SubscriptionPackageDetail");

                entity.Property(e => e.Subscriptionpackagedetailid)
                    .ValueGeneratedNever()
                    .HasColumnName("subscriptionpackagedetailid");

                entity.Property(e => e.Numberofbatchslots).HasColumnName("numberofbatchslots");

                entity.Property(e => e.Serviceid).HasColumnName("serviceid");

                entity.Property(e => e.Serviceproviderexpertserviceid).HasColumnName("serviceproviderexpertserviceid");

                entity.Property(e => e.Serviceproviderserviceid).HasColumnName("serviceproviderserviceid");

                entity.Property(e => e.Subscriptionpackageid).HasColumnName("subscriptionpackageid");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.SubscriptionPackageDetails)
                    .HasForeignKey(d => d.Serviceid)
                    .HasConstraintName("FK_SubscriptionPackageDetail_Service");

                entity.HasOne(d => d.Serviceproviderexpertservice)
                    .WithMany(p => p.SubscriptionPackageDetails)
                    .HasForeignKey(d => d.Serviceproviderexpertserviceid)
                    .HasConstraintName("FK_SubscriptionPackageDetail_ServiceProviderExpertService");

                entity.HasOne(d => d.Serviceproviderservice)
                    .WithMany(p => p.SubscriptionPackageDetails)
                    .HasForeignKey(d => d.Serviceproviderserviceid)
                    .HasConstraintName("FK_SubscriptionPackageDetail_ServiceProviderService");

                entity.HasOne(d => d.Subscriptionpackage)
                    .WithMany(p => p.SubscriptionPackageDetails)
                    .HasForeignKey(d => d.Subscriptionpackageid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubscriptionPackageDetail_SubscriptionPackage");
            });

            modelBuilder.Entity<SubscriptionPackageDetailMapping>(entity =>
            {
                entity.ToTable("SubscriptionPackageDetailMapping");

                entity.Property(e => e.Subscriptionpackagedetailmappingid)
                    .ValueGeneratedNever()
                    .HasColumnName("subscriptionpackagedetailmappingid");

                entity.Property(e => e.Servicecostbyprovider)
                    .HasColumnType("money")
                    .HasColumnName("servicecostbyprovider");

                entity.Property(e => e.Serviceproviderexpertserviceid).HasColumnName("serviceproviderexpertserviceid");

                entity.Property(e => e.Subscriptionpackagedetailid).HasColumnName("subscriptionpackagedetailid");

                entity.HasOne(d => d.Serviceproviderexpertservice)
                    .WithMany(p => p.SubscriptionPackageDetailMappings)
                    .HasForeignKey(d => d.Serviceproviderexpertserviceid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubscriptionPackageDetailMapping_ServiceProviderExpertService");

                entity.HasOne(d => d.Subscriptionpackagedetail)
                    .WithMany(p => p.SubscriptionPackageDetailMappings)
                    .HasForeignKey(d => d.Subscriptionpackagedetailid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubscriptionPackageDetailMapping_SubscriptionPackageDetail");
            });

            modelBuilder.Entity<Thread>(entity =>
            {
                entity.ToTable("Thread");

                entity.Property(e => e.Threadid)
                    .ValueGeneratedNever()
                    .HasColumnName("threadid");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Memberid).HasColumnName("memberid");

                entity.Property(e => e.Serviceproviderexpertid).HasColumnName("serviceproviderexpertid");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Threads)
                    .HasForeignKey(d => d.Memberid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Thread_Member");

                entity.HasOne(d => d.Serviceproviderexpert)
                    .WithMany(p => p.Threads)
                    .HasForeignKey(d => d.Serviceproviderexpertid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Thread_ServiceProviderExpert");
            });

            modelBuilder.Entity<ThreadDocument>(entity =>
            {
                entity.ToTable("ThreadDocument");

                entity.Property(e => e.Threaddocumentid)
                    .ValueGeneratedNever()
                    .HasColumnName("threaddocumentid");

                entity.Property(e => e.Documentdatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("documentdatetime");

                entity.Property(e => e.Documentfromid).HasColumnName("documentfromid");

                entity.Property(e => e.Documentid).HasColumnName("documentid");

                entity.Property(e => e.Threadid).HasColumnName("threadid");

                entity.HasOne(d => d.Documentfrom)
                    .WithMany(p => p.ThreadDocuments)
                    .HasForeignKey(d => d.Documentfromid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ThreadDocument_User");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.ThreadDocuments)
                    .HasForeignKey(d => d.Documentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ThreadDocument_Document");

                entity.HasOne(d => d.Thread)
                    .WithMany(p => p.ThreadDocuments)
                    .HasForeignKey(d => d.Threadid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ThreadDocument_Thread");
            });

            modelBuilder.Entity<ThreadMessage>(entity =>
            {
                entity.ToTable("ThreadMessage");

                entity.Property(e => e.Threadmessageid)
                    .ValueGeneratedNever()
                    .HasColumnName("threadmessageid");

                entity.Property(e => e.Messagedatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("messagedatetime");

                entity.Property(e => e.Messagefromid).HasColumnName("messagefromid");

                entity.Property(e => e.Messagetext)
                    .HasMaxLength(4000)
                    .HasColumnName("messagetext");

                entity.Property(e => e.Threadid).HasColumnName("threadid");

                entity.HasOne(d => d.Messagefrom)
                    .WithMany(p => p.ThreadMessages)
                    .HasForeignKey(d => d.Messagefromid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ThreadMessage_User");

                entity.HasOne(d => d.Thread)
                    .WithMany(p => p.ThreadMessages)
                    .HasForeignKey(d => d.Threadid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ThreadMessage_Thread");
            });

            modelBuilder.Entity<Tribe>(entity =>
            {
                entity.ToTable("Tribe");

                entity.Property(e => e.Tribeid)
                    .ValueGeneratedNever()
                    .HasColumnName("tribeid");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Journalid).HasColumnName("journalid");

                entity.Property(e => e.Publishdatetiime)
                    .HasColumnType("datetime")
                    .HasColumnName("publishdatetiime");

                entity.HasOne(d => d.Journal)
                    .WithMany(p => p.Tribes)
                    .HasForeignKey(d => d.Journalid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tribe_Journal");
            });

            modelBuilder.Entity<TribeComment>(entity =>
            {
                entity.ToTable("TribeComment");

                entity.Property(e => e.Tribecommentid)
                    .ValueGeneratedNever()
                    .HasColumnName("tribecommentid");

                entity.Property(e => e.Commentdatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("commentdatetime");

                entity.Property(e => e.Commenttext)
                    .HasMaxLength(4000)
                    .HasColumnName("commenttext");

                entity.Property(e => e.Tribeid).HasColumnName("tribeid");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Tribe)
                    .WithMany(p => p.TribeComments)
                    .HasForeignKey(d => d.Tribeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TribeComment_Tribe");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TribeComments)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TribeComment_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Userid)
                    .ValueGeneratedNever()
                    .HasColumnName("userid");

                entity.Property(e => e.Emailaddress)
                    .HasMaxLength(200)
                    .HasColumnName("emailaddress");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(200)
                    .HasColumnName("fullname");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Mobilenumber)
                    .HasMaxLength(50)
                    .HasColumnName("mobilenumber");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Roleid).HasColumnName("roleid");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.Property(e => e.Userphotopath)
                    .HasMaxLength(1000)
                    .HasColumnName("userphotopath");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Entity");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
