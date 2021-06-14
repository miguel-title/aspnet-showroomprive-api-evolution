using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AtomicJs.Models.ASTLD
{
    public partial class ASTLDContext : DbContext
    {
        public ASTLDContext()
        {
        }

        public ASTLDContext(DbContextOptions<ASTLDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Component> Components { get; set; }
        public virtual DbSet<ComponentOffer> ComponentOffers { get; set; }
        public virtual DbSet<ComponentUserProfile> ComponentUserProfiles { get; set; }
        public virtual DbSet<DailyJob> DailyJobs { get; set; }
        public virtual DbSet<Licence> Licences { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<OfferCompatibility> OfferCompatibilities { get; set; }
        public virtual DbSet<OfferService> OfferServices { get; set; }
        public virtual DbSet<Tenant> Tenants { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=DESKTOP-2KAC1J2\\SQLEXPRESS;Database=ASTLD;Trusted_Connection=true;");
                optionsBuilder.UseSqlServer("Server=js.atomicseller.com;Database=ASPLD;User Id=P987456HGIYTELJH456BK5678;Password=KLHFJ657496%4RFDdKVI76RFO8;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.Adr1)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Adr2)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientKey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientLicenceProfileId).HasColumnName("ClientLicenceProfileID");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.ConnectionString).IsUnicode(false);

                entity.Property(e => e.ContactName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.ExpiryDate).HasColumnType("date");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReportingEmails).IsUnicode(false);

                entity.Property(e => e.TenantDatabase).IsUnicode(false);

                entity.Property(e => e.TenantDirectory).IsUnicode(false);

                entity.Property(e => e.Token).IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Component>(entity =>
            {
                entity.ToTable("Component");

                entity.Property(e => e.ComponentId).HasColumnName("ComponentID");

                entity.Property(e => e.ComponentKey)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.ComponentName).HasMaxLength(128);

                entity.Property(e => e.MaxLabelsTest)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.MaxShippingsTest)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.MaxStoresTest)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.MaxUsersTest)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ComponentOffer>(entity =>
            {
                entity.HasKey(e => new { e.ComponentId, e.OfferId });

                entity.ToTable("ComponentOffer");

                entity.Property(e => e.ComponentId).HasColumnName("ComponentID");

                entity.Property(e => e.OfferId).HasColumnName("OfferID");
            });

            modelBuilder.Entity<ComponentUserProfile>(entity =>
            {
                entity.HasKey(e => new { e.ComponentId, e.UserProfileId });

                entity.ToTable("ComponentUserProfile");

                entity.Property(e => e.ComponentId).HasColumnName("ComponentID");

                entity.Property(e => e.UserProfileId).HasColumnName("UserProfileID");
            });

            modelBuilder.Entity<DailyJob>(entity =>
            {
                entity.HasKey(e => e.CronId);

                entity.ToTable("DailyJob");

                entity.Property(e => e.CronId).HasColumnName("CronID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.SettingId).HasColumnName("SettingID");
            });

            modelBuilder.Entity<Licence>(entity =>
            {
                entity.ToTable("Licence");

                entity.Property(e => e.LicenceId).HasColumnName("LicenceID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.LicenceStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OfferId).HasColumnName("OfferID");

                entity.Property(e => e.PaymentPeriodicity)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SerialKey)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.ToTable("Offer");

                entity.Property(e => e.OfferId).HasColumnName("OfferID");

                entity.Property(e => e.CustomerType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DownGradeId).HasColumnName("DownGradeID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.OfferName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.OfferSku)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OfferSKU");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.UpgradeId).HasColumnName("UpgradeID");
            });

            modelBuilder.Entity<OfferCompatibility>(entity =>
            {
                entity.ToTable("OfferCompatibility");

                entity.Property(e => e.OfferCompatibilityId).HasColumnName("OfferCompatibilityID");

                entity.Property(e => e.Compatibility)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OfferOwnedId).HasColumnName("OfferOwnedID");

                entity.Property(e => e.OfferProposedId).HasColumnName("OfferProposedID");
            });

            modelBuilder.Entity<OfferService>(entity =>
            {
                entity.ToTable("OfferService");

                entity.Property(e => e.OfferServiceId).HasColumnName("OfferServiceID");

                entity.Property(e => e.Active)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AmountExclVat)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AmountExclVAT");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.OfferId).HasColumnName("OfferID");

                entity.Property(e => e.Periodicity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sku)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SKU");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Vatfr)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VATFR");
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.ToTable("Tenant");

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.Property(e => e.AtomicClientId).HasColumnName("AtomicClientID");

                entity.Property(e => e.AtomicClientKey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.ConnectionString).IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Dbname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DBName");

                entity.Property(e => e.ReportingEmails).IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenantDirectory).IsUnicode(false);

                entity.Property(e => e.Token).IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => new { e.UserId, e.UserName, e.UserProfileId, e.TenantId, e.Apitoken }, "AtomicUserIndex");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Apitoken)
                    .HasMaxLength(2048)
                    .HasColumnName("APIToken");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.MerchantKey)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");

                entity.Property(e => e.PwResetToken).HasMaxLength(512);

                entity.Property(e => e.PwResetTokenValidity).HasColumnType("datetime");

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.Property(e => e.UserEmail).HasMaxLength(128);

                entity.Property(e => e.UserName).HasMaxLength(60);

                entity.Property(e => e.UserProfileId).HasColumnName("UserProfileID");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.ToTable("UserProfile");

                entity.Property(e => e.UserProfileId).HasColumnName("UserProfileID");

                entity.Property(e => e.Comment).HasColumnType("text");

                entity.Property(e => e.ProfileName)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
