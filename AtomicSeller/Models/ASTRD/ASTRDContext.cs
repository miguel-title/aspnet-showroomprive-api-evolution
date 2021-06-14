using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AtomicJs.Models.ASTRD
{
    public partial class ASTRDContext : DbContext
    {
        public ASTRDContext()
        {
        }

        public ASTRDContext(DbContextOptions<ASTRDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<GlobalSetting> GlobalSettings { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<Lang> Langs { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<ReflabelsTemplate> ReflabelsTemplates { get; set; }
        public virtual DbSet<RefstoreCsopistatus> RefstoreCsopistatuses { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Subscribtion> Subscribtions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=DESKTOP-2KAC1J2\\SQLEXPRESS;Database=ASTRD;Trusted_Connection=true;");
                optionsBuilder.UseSqlServer("Server=js.atomicseller.com;Database=ASPRD;User Id=P987456HGIYTELJH456BK5678;Password=KLHFJ657496%4RFDdKVI76RFO8;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("cities");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DepartmentCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("department_code");

                entity.Property(e => e.GpsLat)
                    .HasMaxLength(255)
                    .HasColumnName("gps_lat");

                entity.Property(e => e.GpsLng)
                    .HasMaxLength(255)
                    .HasColumnName("gps_lng");

                entity.Property(e => e.InseeCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("insee_code");

                entity.Property(e => e.IsocountryCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ISOCountryCode");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Slug)
                    .HasMaxLength(255)
                    .HasColumnName("slug");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("zip_code");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.HasIndex(e => new { e.Iso2, e.NameEn, e.NameFr }, "AtomicIndexCountry");

                entity.Property(e => e.Iso2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ISO2");

                entity.Property(e => e.Iso3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ISO3");

                entity.Property(e => e.Ison)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ISON");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NameEN");

                entity.Property(e => e.NameFr)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("departments");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.RegionCode).HasColumnName("region_code");

                entity.Property(e => e.Slug)
                    .HasMaxLength(255)
                    .HasColumnName("slug");
            });

            modelBuilder.Entity<GlobalSetting>(entity =>
            {
                entity.HasKey(e => e.SettingId)
                    .HasName("PK_Settings");

                entity.Property(e => e.SettingId).HasColumnName("SettingID");

                entity.Property(e => e.Key)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.Property(e => e.HolidayId).HasColumnName("HolidayID");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Lib)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingService)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lang>(entity =>
            {
                entity.HasKey(e => e.Token)
                    .HasName("PK_Lang_1");

                entity.ToTable("Lang");

                entity.Property(e => e.Token)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("TOKEN");

                entity.Property(e => e.ArEg).HasColumnName("ar-EG");

                entity.Property(e => e.DeDe).HasColumnName("de-DE");

                entity.Property(e => e.ElGr).HasColumnName("el-GR");

                entity.Property(e => e.EnUs).HasColumnName("en-US");

                entity.Property(e => e.EsEs).HasColumnName("es-ES");

                entity.Property(e => e.Form)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.FrFr).HasColumnName("fr-FR");

                entity.Property(e => e.HiIn).HasColumnName("hi-IN");

                entity.Property(e => e.IdId).HasColumnName("id-ID");

                entity.Property(e => e.ItIt).HasColumnName("it-IT");

                entity.Property(e => e.JaJp).HasColumnName("ja-JP");

                entity.Property(e => e.NlNl).HasColumnName("nl-NL");

                entity.Property(e => e.PlPl).HasColumnName("pl-PL");

                entity.Property(e => e.PtPt).HasColumnName("pt-PT");

                entity.Property(e => e.RuRu).HasColumnName("ru-RU");

                entity.Property(e => e.Type)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.ZhChs).HasColumnName("zh-CHS");

                entity.Property(e => e.ZhTw).HasColumnName("zh-TW");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.CallSite).IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Exception).IsUnicode(false);

                entity.Property(e => e.Level).IsUnicode(false);

                entity.Property(e => e.Logger).IsUnicode(false);

                entity.Property(e => e.MachineName).IsUnicode(false);

                entity.Property(e => e.Message).IsUnicode(false);

                entity.Property(e => e.StackTrace).IsUnicode(false);

                entity.Property(e => e.Thread).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);
            });

            modelBuilder.Entity<ReflabelsTemplate>(entity =>
            {
                entity.HasKey(e => e.TemplateId)
                    .HasName("PK_LabelsTemplate");

                entity.ToTable("REFLabelsTemplate");

                entity.Property(e => e.TemplateId).HasColumnName("TemplateID");

                entity.Property(e => e.ColNb)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ColSpacing)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ColWidth)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DrawLines)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ImageFile)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Key)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LabelHeight)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PageBottomMargin)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PageFooterHeight)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PageHeaderHeight)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PageHeight)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PageLeftMargin)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PageRightMargin)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PageTopMargin)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PageWidth)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row1Font)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Row1FontSize)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row1FontWeight)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Row1Height)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row1Text)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Row2Font)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Row2FontSize)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row2FontWeight)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Row2Height)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row2Text)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Row3Font)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Row3FontSize)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row3FontWeight)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Row3Height)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row3Text)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Row4Font)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Row4FontSize)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row4FontWeight)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Row4Height)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row4Text)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Row5Font)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Row5FontSize)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row5FontWeight)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Row5Height)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row5Text)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Row6Font)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Row6FontSize)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row6FontWeight)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Row6Height)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row6Text)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Row7Font)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Row7FontSize)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row7FontWeight)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Row7Height)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row7Text)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Row8Font)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Row8FontSize)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row8FontWeight)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Row8Height)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row8Text)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.RowNb)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RowSpacing)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RowsPerLabel)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Unit)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefstoreCsopistatus>(entity =>
            {
                entity.HasKey(e => e.RefcsopistatusId);

                entity.ToTable("REFStoreCSOPIStatus");

                entity.Property(e => e.RefcsopistatusId).HasColumnName("REFCSOPIStatusID");

                entity.Property(e => e.Refcsopikey)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REFCSOPIKEY");

                entity.Property(e => e.RefcsopistatusExternalName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REFCSOPIStatusExternalName");

                entity.Property(e => e.RefcsopistoreType).HasColumnName("REFCSOPIStoreType");

                entity.Property(e => e.Refcsopitoken)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("REFCSOPITOKEN");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("regions");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Slug)
                    .HasMaxLength(255)
                    .HasColumnName("slug");
            });

            modelBuilder.Entity<Subscribtion>(entity =>
            {
                entity.HasKey(e => e.SubscripbtionId);

                entity.Property(e => e.SubscripbtionId).HasColumnName("SubscripbtionID");

                entity.Property(e => e.Adr1).IsUnicode(false);

                entity.Property(e => e.Adr2).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.CompanyName).IsUnicode(false);

                entity.Property(e => e.CompanyRegistrationNumber).IsUnicode(false);

                entity.Property(e => e.ContactName).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.FirstUserEmail).IsUnicode(false);

                entity.Property(e => e.FirstUserPassword).IsUnicode(false);

                entity.Property(e => e.Ip)
                    .IsUnicode(false)
                    .HasColumnName("IP");

                entity.Property(e => e.Ipinfo)
                    .IsUnicode(false)
                    .HasColumnName("IPInfo");

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.Sku)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("SKU");

                entity.Property(e => e.UserName).IsUnicode(false);

                entity.Property(e => e.Vatnumber)
                    .IsUnicode(false)
                    .HasColumnName("VATNumber");

                entity.Property(e => e.Zip).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
