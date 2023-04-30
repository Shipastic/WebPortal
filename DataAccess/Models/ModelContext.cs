using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Entities.Models;
using Infrastructures.Interfaces.DataAccess.Interfaces.Infrastructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Infrastructures.Implementation.DataAccess.Oracle.Models
{
    public partial class ModelContext : IdentityDbContext<ApplicationUser>, IModelContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public DbSet<Contractor> Contractors { get; set; } = null!;
        public DbSet<IrisSdCategory> IrisSdCategories { get; set; } = null!;
        public virtual DbSet<IrisSdCompany> IrisSdCompanies { get; set; } = null!;
        public virtual DbSet<IrisSdGrpLink> IrisSdGrpLinks { get; set; } = null!;
        public virtual DbSet<IrisSdGrpObj> IrisSdGrpObjs { get; set; } = null!;
        public virtual DbSet<IrisSdService> IrisSdServices { get; set; } = null!;
        public virtual DbSet<IrisSdSla> IrisSdSlas { get; set; } = null!;

        public Task<int> SaveChangeAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=__)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=__P)));User ID=lider;Password=__;Persist Security Info=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("LIDER")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Contractor>(entity =>
            {
                entity.ToTable("CONTRACTOR");

                entity.HasIndex(e => e.ContractorTypeId, "CONTARCTOR_TYPE_FK");

                entity.HasIndex(e => new { e.ShortName, e.Inn, e.Bic, e.RegDate, e.Name, e.CityId }, "CONTRACTOR_AK1")
                    .IsUnique();

                entity.HasIndex(e => new { e.EntId, e.RegDate }, "CONTRACTOR_AK2")
                    .IsUnique();

                entity.HasIndex(e => new { e.EntId, e.NextRegDate }, "CONTRACTOR_AK3")
                    .IsUnique();

                entity.HasIndex(e => e.BoardId, "CONTRACTOR_BOARD_FK");

                entity.HasIndex(e => e.CityId, "CONTRACTOR_CITY_FK");

                entity.HasIndex(e => e.EntId, "CONTRACTOR_ENT_FK");

                entity.HasIndex(e => e.EstablishmentId, "CONTRACTOR_ESTABLISHMENT_FK");

                entity.Property(e => e.Id)
                    .HasPrecision(18)
                    .HasColumnName("ID");

                entity.Property(e => e.Bic)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BIC");

                entity.Property(e => e.BoardId)
                    .HasPrecision(18)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BOARD_ID")
                    .HasDefaultValueSql("NULL ");

                entity.Property(e => e.CityId)
                    .HasPrecision(18)
                    //.ValueGeneratedOnAdd()
                    .HasColumnName("CITY_ID");

                entity.Property(e => e.CloseDate)
                    .HasColumnType("DATE")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CLOSE_DATE");

                entity.Property(e => e.ContractorTypeId)
                    .HasPrecision(18)
                    //.ValueGeneratedOnAdd()
                    .HasColumnName("CONTRACTOR_TYPE_ID");

                entity.Property(e => e.EntId)
                    .HasPrecision(18)
                    //.ValueGeneratedOnAdd()
                    .HasColumnName("ENT_ID");

                entity.Property(e => e.EstablishmentId)
                    .HasPrecision(18)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ESTABLISHMENT_ID")
                    .HasDefaultValueSql("NULL ");

                entity.Property(e => e.Inn)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("INN");

                entity.Property(e => e.Name)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NAME");

                entity.Property(e => e.NextCloseDate)
                    .HasColumnType("DATE")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NEXT_CLOSE_DATE")
                    .HasDefaultValueSql("TO_DATE('01.01.2999','DD.MM.YYYY') ");

                entity.Property(e => e.NextRegDate)
                    .HasColumnType("DATE")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NEXT_REG_DATE")
                    .HasDefaultValueSql("TO_DATE('01.01.2999','DD.MM.YYYY') ");

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NOTE");

                entity.Property(e => e.RegDate)
                    .HasColumnType("DATE")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("REG_DATE");

                entity.Property(e => e.ShortName)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SHORT_NAME");
            });

            modelBuilder.Entity<IrisSdCategory>(entity =>
            {
                entity.ToTable("IRIS_SD_CATEGORY");

                entity.Property(e => e.Id)
                    .HasPrecision(18)
                    .HasColumnName("ID");

                entity.Property(e => e.NameIs)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("NAME_IS");

                entity.Property(e => e.NameIs2)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("NAME_IS2");

                entity.Property(e => e.Note)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("NOTE");

                entity.Property(e => e.OtrsValue)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("OTRS_VALUE");

                entity.Property(e => e.Priority)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("PRIORITY");

                entity.Property(e => e.SdServId)
                    .HasPrecision(18)
                    .HasColumnName("SD_SERV_ID");

                entity.HasOne(d => d.SdServ)
                    .WithMany(p => p.IrisSdCategories)
                    .HasForeignKey(d => d.SdServId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IRIS_SD_CATEGORY_SERV_ID_FK");
            });

            modelBuilder.Entity<IrisSdCompany>(entity =>
            {
                entity.ToTable("IRIS_SD_COMPANY");

                entity.Property(e => e.Id)
                    .HasPrecision(18)
                    .HasColumnName("ID");

                entity.Property(e => e.CntId)
                    .HasPrecision(18)
                    .HasColumnName("CNT_ID");

                entity.Property(e => e.NameIs)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("NAME_IS");

                entity.Property(e => e.NameIs2)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("NAME_IS2");

                entity.Property(e => e.Note)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("NOTE");

                entity.Property(e => e.OtrsValue)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("OTRS_VALUE");
            });

            modelBuilder.Entity<IrisSdGrpLink>(entity =>
            {
                entity.ToTable("IRIS_SD_GRP_LINK");

                entity.Property(e => e.Id)
                    .HasPrecision(18)
                    .HasColumnName("ID");

                entity.Property(e => e.GrpObjId)
                    .HasPrecision(18)
                    .HasColumnName("GRP_OBJ_ID");

                entity.Property(e => e.Note)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("NOTE");

                entity.Property(e => e.OtrsValue)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("OTRS_VALUE");

                entity.Property(e => e.SdSlaId)
                    .HasPrecision(18)
                    .HasColumnName("SD_SLA_ID");

                entity.HasOne(d => d.GrpObj)
                    .WithMany(p => p.IrisSdGrpLinks)
                    .HasForeignKey(d => d.GrpObjId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IRIS_SD_GRP_LINK_GRP_FK");

                entity.HasOne(d => d.SdSla)
                    .WithMany(p => p.IrisSdGrpLinks)
                    .HasForeignKey(d => d.SdSlaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IRIS_SD_GRP_LINK_SLA_FK");
            });

            modelBuilder.Entity<IrisSdGrpObj>(entity =>
            {
                entity.ToTable("IRIS_SD_GRP_OBJ");

                entity.Property(e => e.Id)
                    .HasPrecision(18)
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Note)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("NOTE");
            });

            modelBuilder.Entity<IrisSdService>(entity =>
            {
                entity.ToTable("IRIS_SD_SERVICE");

                entity.Property(e => e.Id)
                    .HasPrecision(18)
                    .HasColumnName("ID");

                entity.Property(e => e.NameIs)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("NAME_IS");

                entity.Property(e => e.NameIs2)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("NAME_IS2");

                entity.Property(e => e.Note)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("NOTE");

                entity.Property(e => e.OtrsValue)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("OTRS_VALUE");

                entity.Property(e => e.SdCompId)
                    .HasPrecision(18)
                    .HasColumnName("SD_COMP_ID");

                entity.HasOne(d => d.SdComp)
                    .WithMany(p => p.IrisSdServices)
                    .HasForeignKey(d => d.SdCompId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IRIS_SD_SERVICE_COMP_ID_FK");
            });

            modelBuilder.Entity<IrisSdSla>(entity =>
            {
                entity.ToTable("IRIS_SD_SLA");

                entity.Property(e => e.Id)
                    .HasPrecision(18)
                    .HasColumnName("ID");

                entity.Property(e => e.NameIs)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("NAME_IS");

                entity.Property(e => e.NameIs2)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("NAME_IS2");

                entity.Property(e => e.Note)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("NOTE");

                entity.Property(e => e.OtrsValue)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("OTRS_VALUE");

                entity.Property(e => e.SdCatId)
                    .HasPrecision(18)
                    .HasColumnName("SD_CAT_ID");

                entity.HasOne(d => d.SdCat)
                    .WithMany(p => p.IrisSdSlas)
                    .HasForeignKey(d => d.SdCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IRIS_SD_SLA_CAT_ID_FK");
            });

            modelBuilder.HasSequence("ANALYSIS_WORK_SEQ").IsCyclic();

            modelBuilder.HasSequence("CNT_NOT_FIELD_REPLACE_SQ").IsCyclic();

            modelBuilder.HasSequence("CNT_REPLACE_SQ").IsCyclic();

            modelBuilder.HasSequence("CNT_TABLE_REPLACE_SQ").IsCyclic();

            modelBuilder.HasSequence("CNT_UNION_SQ").IsCyclic();

            modelBuilder.HasSequence("GDS_PRICE_TMP_SQ").IsCyclic();

            modelBuilder.HasSequence("IN_PAY_LINE_DEC_SQ").IsCyclic();

            modelBuilder.HasSequence("PLSQL_PROFILER_RUNNUMBER").IsCyclic();

            modelBuilder.HasSequence("SALE_CALC_TREATY_CALC_SQ").IsCyclic();

            modelBuilder.HasSequence("SALE_CALC_TREATY_SQ").IsCyclic();

            modelBuilder.HasSequence("SEQ_IRIS_LOG_TBL").IsCyclic();

            modelBuilder.HasSequence("SEQ_SYM_DATA_DATA_ID");

            modelBuilder.HasSequence("SQ_ACC_KEEP_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_ACC_MAP").IsCyclic();

            modelBuilder.HasSequence("SQ_ACC_PERIOD").IsCyclic();

            modelBuilder.HasSequence("SQ_ACC_PERIOD_CTRL").IsCyclic();

            modelBuilder.HasSequence("SQ_ACC_PERIOD_NAME").IsCyclic();

            modelBuilder.HasSequence("SQ_ACC_PERIOD_SRVR").IsCyclic();

            modelBuilder.HasSequence("SQ_ACC_PERIOD_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_ACC_REL").IsCyclic();

            modelBuilder.HasSequence("SQ_ACC_SAL_DEP").IsCyclic();

            modelBuilder.HasSequence("SQ_ACC_SYN").IsCyclic();

            modelBuilder.HasSequence("SQ_ACC_SYN_BOND").IsCyclic();

            modelBuilder.HasSequence("SQ_ACC_SYN_DOC_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_ACC_SYN_ENT").IsCyclic();

            modelBuilder.HasSequence("SQ_ACC_SYN_FDS").IsCyclic();

            modelBuilder.HasSequence("SQ_ACC_TRANSACTION").IsCyclic();

            modelBuilder.HasSequence("SQ_ACC_TSET").IsCyclic();

            modelBuilder.HasSequence("SQ_ACC_TSET_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_ACC_TSET_EXT").IsCyclic();

            modelBuilder.HasSequence("SQ_ACC_TSET_FDS").IsCyclic();

            modelBuilder.HasSequence("SQ_ACC_TSET_GRP").IsCyclic();

            modelBuilder.HasSequence("SQ_ACC_TSET_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_ACCEPT_ACT_COMM").IsCyclic();

            modelBuilder.HasSequence("SQ_ACCEPT_MOTOR_DOP").IsCyclic();

            modelBuilder.HasSequence("SQ_ACCEPT_REPORT_EXT").IsCyclic();

            modelBuilder.HasSequence("SQ_ACCEPT_REPORT_STR_ACC").IsCyclic();

            modelBuilder.HasSequence("SQ_ACCOUNT").IsCyclic();

            modelBuilder.HasSequence("SQ_ACCOUNT_BANK").IsCyclic();

            modelBuilder.HasSequence("SQ_ACCOUNT_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_ACT_FORM_13_M").IsCyclic();

            modelBuilder.HasSequence("SQ_ADA_TMP_ITEM").IsCyclic();

            modelBuilder.HasSequence("SQ_ADA_TMP_REGION").IsCyclic();

            modelBuilder.HasSequence("SQ_ADA_TMP_SALE").IsCyclic();

            modelBuilder.HasSequence("SQ_ADDRESS").IsCyclic();

            modelBuilder.HasSequence("SQ_ADM_CONJ_CHILD").IsCyclic();

            modelBuilder.HasSequence("SQ_ADM_CONJ_ELEM").IsCyclic();

            modelBuilder.HasSequence("SQ_ADM_CONJ_TABLE").IsCyclic();

            modelBuilder.HasSequence("SQ_ADM_DW").IsCyclic();

            modelBuilder.HasSequence("SQ_ADM_DWLOV").IsCyclic();

            modelBuilder.HasSequence("SQ_ADM_DWSELECT").IsCyclic();

            modelBuilder.HasSequence("SQ_ADM_DWSORT").IsCyclic();

            modelBuilder.HasSequence("SQ_ADM_SEQUENCE").IsCyclic();

            modelBuilder.HasSequence("SQ_ALARM_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_AMORTIZATION_METHOD").IsCyclic();

            modelBuilder.HasSequence("SQ_AMORTIZATION_RESP").IsCyclic();

            modelBuilder.HasSequence("SQ_AMORTIZATION_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_ANA_SUBJ_PERMIT").IsCyclic();

            modelBuilder.HasSequence("SQ_ANALYSIS_EVENT").IsCyclic();

            modelBuilder.HasSequence("SQ_ANKREST").IsCyclic();

            modelBuilder.HasSequence("SQ_AO_CALC_ERROR").IsCyclic();

            modelBuilder.HasSequence("SQ_AO_DD").IsCyclic();

            modelBuilder.HasSequence("SQ_AO_DELIV_PLAN").IsCyclic();

            modelBuilder.HasSequence("SQ_AO_DELIV_PLAN_I").IsCyclic();

            modelBuilder.HasSequence("SQ_AO_DEMAND_DETAIL").IsCyclic();

            modelBuilder.HasSequence("SQ_AO_GROUP_AZS").IsCyclic();

            modelBuilder.HasSequence("SQ_AO_PARAM").IsCyclic();

            modelBuilder.HasSequence("SQ_AO_PARAM_ACTION").IsCyclic();

            modelBuilder.HasSequence("SQ_AO_PARAM_GDS").IsCyclic();

            modelBuilder.HasSequence("SQ_AO_PARAM_PREDICT").IsCyclic();

            modelBuilder.HasSequence("SQ_AO_PARAM_SUPP").IsCyclic();

            modelBuilder.HasSequence("SQ_AO_SUPP_GROUP_DELIV").IsCyclic();

            modelBuilder.HasSequence("SQ_AO_WARN");

            modelBuilder.HasSequence("SQ_AO_WARN_HEAD");

            modelBuilder.HasSequence("SQ_AOBOL").IsCyclic();

            modelBuilder.HasSequence("SQ_ASSAY").IsCyclic();

            modelBuilder.HasSequence("SQ_ASSAY_CONCLUSION").IsCyclic();

            modelBuilder.HasSequence("SQ_ASSAY_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_ASSET_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_ASSIGN_ACT_COMM").IsCyclic();

            modelBuilder.HasSequence("SQ_ASSIGNEE_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_ASSIGNEE_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_ASSIGNEE_PERSON").IsCyclic();

            modelBuilder.HasSequence("SQ_ASSIGNEE_RIGHT").IsCyclic();

            modelBuilder.HasSequence("SQ_ASSIGNMENT").IsCyclic();

            modelBuilder.HasSequence("SQ_ASSIGNMENT_ACT_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_ASSORTMENT_CNT").IsCyclic();

            modelBuilder.HasSequence("SQ_ASSORTMENT_CNT_EX").IsCyclic();

            modelBuilder.HasSequence("SQ_ASSORTMENT_CNT_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_ASSORTMENT_CNT_GROUP_EX").IsCyclic();

            modelBuilder.HasSequence("SQ_ASUTP_EL_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_ASUTP_ELEMENT").IsCyclic();

            modelBuilder.HasSequence("SQ_AUDIT_ERROR").IsCyclic();

            modelBuilder.HasSequence("SQ_AUDIT_KAMA_CARD_STATUS").IsCyclic();

            modelBuilder.HasSequence("SQ_AUDIT_KAMA_READER_LOG").IsCyclic();

            modelBuilder.HasSequence("SQ_AVD_SR_CTRL_ALL").IsCyclic();

            modelBuilder.HasSequence("SQ_AWARD").IsCyclic();

            modelBuilder.HasSequence("SQ_AZS_ASSORTMENT_GOODS_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_AZS_KASU_CONFIG").IsCyclic();

            modelBuilder.HasSequence("SQ_AZS_KASU_ERROR").IsCyclic();

            modelBuilder.HasSequence("SQ_AZS_KASU_GOODS_STOP").IsCyclic();

            modelBuilder.HasSequence("SQ_BANK").IsCyclic();

            modelBuilder.HasSequence("SQ_BANK_DOCUMENT_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_BITRIX_MATERIAL").IsCyclic();

            modelBuilder.HasSequence("SQ_BOLT").IsCyclic();

            modelBuilder.HasSequence("SQ_BOOKMARK").IsCyclic();

            modelBuilder.HasSequence("SQ_BOOKMARK_CLOSE").IsCyclic();

            modelBuilder.HasSequence("SQ_BUSH").IsCyclic();

            modelBuilder.HasSequence("SQ_BUSH_MEMBER").IsCyclic();

            modelBuilder.HasSequence("SQ_BUSH_UNIT").IsCyclic();

            modelBuilder.HasSequence("SQ_BUSINESS_TRIP").IsCyclic();

            modelBuilder.HasSequence("SQ_BUSINESS_TRIP_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_BUYER_STRUCT").IsCyclic();

            modelBuilder.HasSequence("SQ_CA_ACCESSORY").IsCyclic();

            modelBuilder.HasSequence("SQ_CA_CARD").IsCyclic();

            modelBuilder.HasSequence("SQ_CA_CARD_BASE").IsCyclic();

            modelBuilder.HasSequence("SQ_CA_CARD_COEFF").IsCyclic();

            modelBuilder.HasSequence("SQ_CA_CARD_PERCENT").IsCyclic();

            modelBuilder.HasSequence("SQ_CA_CARD_RESPONS").IsCyclic();

            modelBuilder.HasSequence("SQ_CA_CARD_STATE").IsCyclic();

            modelBuilder.HasSequence("SQ_CA_CARD_TUNING").IsCyclic();

            modelBuilder.HasSequence("SQ_CA_DOWN_COMM").IsCyclic();

            modelBuilder.HasSequence("SQ_CA_INSURANCE").IsCyclic();

            modelBuilder.HasSequence("SQ_CA_INV_LIST_COMM").IsCyclic();

            modelBuilder.HasSequence("SQ_CA_METHOD_TUNING").IsCyclic();

            modelBuilder.HasSequence("SQ_CA_MOVING_I").IsCyclic();

            modelBuilder.HasSequence("SQ_CA_OKOF").IsCyclic();

            modelBuilder.HasSequence("SQ_CA_PAR_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_CA_PARAM_CNT_VALUE").IsCyclic();

            modelBuilder.HasSequence("SQ_CA_PARAM_VALUE").IsCyclic();

            modelBuilder.HasSequence("SQ_CA_PARAMETER").IsCyclic();

            modelBuilder.HasSequence("SQ_CA_STRUCTURE").IsCyclic();

            modelBuilder.HasSequence("SQ_CA_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_CA_TYPE_BASE").IsCyclic();

            modelBuilder.HasSequence("SQ_CA_TYPE_COEFF").IsCyclic();

            modelBuilder.HasSequence("SQ_CA_TYPE_PERCENT").IsCyclic();

            modelBuilder.HasSequence("SQ_CA_TYPE_TUNING").IsCyclic();

            modelBuilder.HasSequence("SQ_CALC_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_CALC_TAX_PHASE").IsCyclic();

            modelBuilder.HasSequence("SQ_CALEND_DAY").IsCyclic();

            modelBuilder.HasSequence("SQ_CALEND_MONTH").IsCyclic();

            modelBuilder.HasSequence("SQ_CALEND_WEEK_DAY").IsCyclic();

            modelBuilder.HasSequence("SQ_CALEND_WEEK_NUM").IsCyclic();

            modelBuilder.HasSequence("SQ_CALEND_YEAR").IsCyclic();

            modelBuilder.HasSequence("SQ_CALENDAR").IsCyclic();

            modelBuilder.HasSequence("SQ_CAPACITY_COEFF").IsCyclic();

            modelBuilder.HasSequence("SQ_CAR_CAPACITY").IsCyclic();

            modelBuilder.HasSequence("SQ_CAR_DELTA_VOLUME").IsCyclic();

            modelBuilder.HasSequence("SQ_CAR_LICARD").IsCyclic();

            modelBuilder.HasSequence("SQ_CAR_MODEL").IsCyclic();

            modelBuilder.HasSequence("SQ_CAR_RESPONS").IsCyclic();

            modelBuilder.HasSequence("SQ_CAR_TARIF").IsCyclic();

            modelBuilder.HasSequence("SQ_CAR_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_CAR_VOLUME").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_ACC_AIM").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_ACC_HNDL").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_ACC_HNDL_ENT").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_ACC_NET").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_ACC_VAL").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_ANA_SUBJ_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_ANA_SUBJ_HIER").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_ANA_SUBJECT").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_ANA_VAL").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_ANA_VAL_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_BANK_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_BLACK_LIST").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_GDS").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_GDS_AIM").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_GDS_CHECK").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_GDS_FLOW").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_GDS_NET").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_GDS_STOR").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_GDS_STOR_FLOW").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_GDS_STOR_NET").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_GDS_VAL").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_HANDLER").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_HANDLER_ENT").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_OPER_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_STATUS").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_STOR").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_STOR_CHECK").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_STOR_FLOW").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_STOR_NET").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_SUBJECT").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_TAX_AIM").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_TAX_SUBJ_HIER").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_TAX_VAL").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_TRAN_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_CARD_TYPE_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_CARGO_SENDER").IsCyclic();

            modelBuilder.HasSequence("SQ_CASH_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_CASH_RECOVERY").IsCyclic();

            modelBuilder.HasSequence("SQ_CASH_REGISTER").IsCyclic();

            modelBuilder.HasSequence("SQ_CASH_SECTION").IsCyclic();

            modelBuilder.HasSequence("SQ_CASH_SELLING_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_CASH_TEST").IsCyclic();

            modelBuilder.HasSequence("SQ_CASH_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_CATEGORY_QUALIFICATION").IsCyclic();

            modelBuilder.HasSequence("SQ_CERT_EXP_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_CERTIFICATE").IsCyclic();

            modelBuilder.HasSequence("SQ_CERTIFICATE_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_CERTIFICATE_ROLE").IsCyclic();

            modelBuilder.HasSequence("SQ_CHANGE_DEP_HIERARCHY").IsCyclic();

            modelBuilder.HasSequence("SQ_CHEQUE").IsCyclic();

            modelBuilder.HasSequence("SQ_CHEQUE_DISCOUNT").IsCyclic();

            modelBuilder.HasSequence("SQ_CHEQUE_LINE").IsCyclic();

            modelBuilder.HasSequence("SQ_CHEQUE_LINE_ADDITION").IsCyclic();

            modelBuilder.HasSequence("SQ_CHEQUE_LINE_PAYMENT").IsCyclic();

            modelBuilder.HasSequence("SQ_CHERNOBYL").IsCyclic();

            modelBuilder.HasSequence("SQ_CITY").IsCyclic();

            modelBuilder.HasSequence("SQ_CITY_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_CLAIM_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_CNT_APPEARANCE").IsCyclic();

            modelBuilder.HasSequence("SQ_CNT_BOARD").IsCyclic();

            modelBuilder.HasSequence("SQ_CNT_PARAMETER").IsCyclic();

            modelBuilder.HasSequence("SQ_CNT_PROPERTY").IsCyclic();

            modelBuilder.HasSequence("SQ_CNT_PROPERTY_NAME").IsCyclic();

            modelBuilder.HasSequence("SQ_CNT_RAILWAY_STATION").IsCyclic();

            modelBuilder.HasSequence("SQ_CNT_TYPE_PROPERTY").IsCyclic();

            modelBuilder.HasSequence("SQ_CO_DEMAND_NUM").IsCyclic();

            modelBuilder.HasSequence("SQ_COEFF_PERIOD").IsCyclic();

            modelBuilder.HasSequence("SQ_COMP_GOODS").IsCyclic();

            modelBuilder.HasSequence("SQ_COMP_SHEET_SUPP").IsCyclic();

            modelBuilder.HasSequence("SQ_COND_COEFF").IsCyclic();

            modelBuilder.HasSequence("SQ_COND_OPERATION").IsCyclic();

            modelBuilder.HasSequence("SQ_CONSERVE_ACT_COMM").IsCyclic();

            modelBuilder.HasSequence("SQ_CONSERVE_END_COMM").IsCyclic();

            modelBuilder.HasSequence("SQ_CONSERVE_PROT_COMM").IsCyclic();

            modelBuilder.HasSequence("SQ_CONSUME_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_CONTRACTOR").IsCyclic();

            modelBuilder.HasSequence("SQ_CONTRACTOR_ROLE").IsCyclic();

            modelBuilder.HasSequence("SQ_CONTRACTOR_SUBTYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_CONTRACTOR_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_CORP_STRUCTURE").IsCyclic();

            modelBuilder.HasSequence("SQ_CORRECT_REST_AGG").IsCyclic();

            modelBuilder.HasSequence("SQ_COSTOFF_RESP").IsCyclic();

            modelBuilder.HasSequence("SQ_COUNTER").IsCyclic();

            modelBuilder.HasSequence("SQ_COUNTRY").IsCyclic();

            modelBuilder.HasSequence("SQ_COUNTRY_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_COUNTRY_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_COUNTRY_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_COUPON_FLOW").IsCyclic();

            modelBuilder.HasSequence("SQ_COUPON_ROLL").IsCyclic();

            modelBuilder.HasSequence("SQ_COUPON_STOP").IsCyclic();

            modelBuilder.HasSequence("SQ_COURSES").IsCyclic();

            modelBuilder.HasSequence("SQ_COURSES_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_CREW").IsCyclic();

            modelBuilder.HasSequence("SQ_CREW_PERSONNEL").IsCyclic();

            modelBuilder.HasSequence("SQ_CRITERION_EVENT").IsCyclic();

            modelBuilder.HasSequence("SQ_CUR_ERROR_VAL").IsCyclic();

            modelBuilder.HasSequence("SQ_CUR_OPERATOR").IsCyclic();

            modelBuilder.HasSequence("SQ_CURRENCY").IsCyclic();

            modelBuilder.HasSequence("SQ_CURRENCY_VALUE").IsCyclic();

            modelBuilder.HasSequence("SQ_CURRENT_CA_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_CUST_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_CUST_GROUP_PRICE").IsCyclic();

            modelBuilder.HasSequence("SQ_DECLARATION_ITEM").IsCyclic();

            modelBuilder.HasSequence("SQ_DELIVERY_DIR_COEFF").IsCyclic();

            modelBuilder.HasSequence("SQ_DELIVERY_STATUS_TAG").IsCyclic();

            modelBuilder.HasSequence("SQ_DEMAND_CORR_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_DEMAND_WEB").IsCyclic();

            modelBuilder.HasSequence("SQ_DENCITY20").IsCyclic();

            modelBuilder.HasSequence("SQ_DEPARTMENT").IsCyclic();

            modelBuilder.HasSequence("SQ_DEPARTMENT_INFO").IsCyclic();

            modelBuilder.HasSequence("SQ_DEPARTMENT_PERS_BOOK").IsCyclic();

            modelBuilder.HasSequence("SQ_DEPENDENT_SCHEME").IsCyclic();

            modelBuilder.HasSequence("SQ_DESTINATION_PAYMENT").IsCyclic();

            modelBuilder.HasSequence("SQ_DISABILITY_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_DISABLED_STROKE_CODE").IsCyclic();

            modelBuilder.HasSequence("SQ_DISABLEMENT").IsCyclic();

            modelBuilder.HasSequence("SQ_DISCOUNT").IsCyclic();

            modelBuilder.HasSequence("SQ_DISCOUNT_AMOUNT").IsCyclic();

            modelBuilder.HasSequence("SQ_DISCOUNT_FDS").IsCyclic();

            modelBuilder.HasSequence("SQ_DISCOUNT_QNT").IsCyclic();

            modelBuilder.HasSequence("SQ_DISCOUNT_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_DISEASE_LIST").IsCyclic();

            modelBuilder.HasSequence("SQ_DISEASE_LIST_POS").IsCyclic();

            modelBuilder.HasSequence("SQ_DISEASE_REGIMENT").IsCyclic();

            modelBuilder.HasSequence("SQ_DISLOCATION").IsCyclic();

            modelBuilder.HasSequence("SQ_DISTR_PLASTIC_CARD").IsCyclic();

            modelBuilder.HasSequence("SQ_DNA_DELIV_ADDR").IsCyclic();

            modelBuilder.HasSequence("SQ_DNA_ORDER").IsCyclic();

            modelBuilder.HasSequence("SQ_DNA_ORDER_DELIV").IsCyclic();

            modelBuilder.HasSequence("SQ_DNA_ORDER_ITEM").IsCyclic();

            modelBuilder.HasSequence("SQ_DNA_PERSON").IsCyclic();

            modelBuilder.HasSequence("SQ_DNA_PROD_GRP").IsCyclic();

            modelBuilder.HasSequence("SQ_DNA_PRODUCT").IsCyclic();

            modelBuilder.HasSequence("SQ_DNA_SESSION").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_ACTION").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_ACTION_DT").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_ACTIVITY").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_ACTIVITY_DT").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_ATTACHMENT").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_CONDITION").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_CONDITION_DT").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_CORREL").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_DEFAULT_PARAM").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_EVENT").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_EVENT_DT").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_EXT").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_LINE").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_LINE_TRAN").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_LINE_TRANSITION").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_LINE_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_LINE_TYPE_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_MULTIORG").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_NUM").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_NUM_HOLE").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_NUM_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_NUM_TYPE_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_PLACE").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_PLACE_TERM").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_PLACE_USER").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_STATE_DEPEND").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_TABLE_TO_BE_REPL").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_TRAN").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_TRAN_PLACE").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_TRANSITION").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_TYPE_STORNO_COL").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_VALUE").IsCyclic();

            modelBuilder.HasSequence("SQ_DOC_VISA").IsCyclic();

            modelBuilder.HasSequence("SQ_DOCUMENT").IsCyclic();

            modelBuilder.HasSequence("SQ_DOCUMENT_ACCESS").IsCyclic();

            modelBuilder.HasSequence("SQ_DOCUMENT_COMMENT").IsCyclic();

            modelBuilder.HasSequence("SQ_DOCUMENT_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_DOWN_MATERIAL_COMM").IsCyclic();

            modelBuilder.HasSequence("SQ_DRIVER").IsCyclic();

            modelBuilder.HasSequence("SQ_DRIVER_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_DUT_ACCOUNT").IsCyclic();

            modelBuilder.HasSequence("SQ_DUT_AUX_SLIP_POOL").IsCyclic();

            modelBuilder.HasSequence("SQ_DUT_BUDGET").IsCyclic();

            modelBuilder.HasSequence("SQ_DUT_CALC_PERIOD").IsCyclic();

            modelBuilder.HasSequence("SQ_DUT_CHARGE_POOL").IsCyclic();

            modelBuilder.HasSequence("SQ_DUT_DISTR_INP_TERR").IsCyclic();

            modelBuilder.HasSequence("SQ_DUT_FORMULA_PERIOD").IsCyclic();

            modelBuilder.HasSequence("SQ_DUT_NAME_PERIOD").IsCyclic();

            modelBuilder.HasSequence("SQ_DUT_POOL_POSITION").IsCyclic();

            modelBuilder.HasSequence("SQ_DUT_PURPOSE_PERIOD").IsCyclic();

            modelBuilder.HasSequence("SQ_DUT_TYPE_CALCULATE").IsCyclic();

            modelBuilder.HasSequence("SQ_DUT_TYPE_PAYMENT").IsCyclic();

            modelBuilder.HasSequence("SQ_E_DOC_CLASS").IsCyclic();

            modelBuilder.HasSequence("SQ_E_DOC_DSS_SERT_OWNERS").IsCyclic();

            modelBuilder.HasSequence("SQ_E_DOC_FIELD_RULE").IsCyclic();

            modelBuilder.HasSequence("SQ_E_DOC_SIGN_REPORT").IsCyclic();

            modelBuilder.HasSequence("SQ_E_DOC_SIGN_RULE").IsCyclic();

            modelBuilder.HasSequence("SQ_E_DOC_SIGNATURE").IsCyclic();

            modelBuilder.HasSequence("SQ_E_DOC_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_E_DOC_VAL").IsCyclic();

            modelBuilder.HasSequence("SQ_E_DOC_XMLTYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_E_PARTNER").IsCyclic();

            modelBuilder.HasSequence("SQ_E_PARTNER_DOC").IsCyclic();

            modelBuilder.HasSequence("SQ_E_SYSTEM_DOC").IsCyclic();

            modelBuilder.HasSequence("SQ_E_TABLE_FIELD").IsCyclic();

            modelBuilder.HasSequence("SQ_E_XML_TEMPLATE").IsCyclic();

            modelBuilder.HasSequence("SQ_ECONOMIC_REGION").IsCyclic();

            modelBuilder.HasSequence("SQ_EDUCATIONAL_INSTITUT").IsCyclic();

            modelBuilder.HasSequence("SQ_ELEM_CALC_ANA_VAL").IsCyclic();

            modelBuilder.HasSequence("SQ_ELEM_TRAN_SUBJ_VAL").IsCyclic();

            modelBuilder.HasSequence("SQ_EM_LINK").IsCyclic();

            modelBuilder.HasSequence("SQ_EM_REF_ITEMS").IsCyclic();

            modelBuilder.HasSequence("SQ_EM_REF_ITEMS_ATTR").IsCyclic();

            modelBuilder.HasSequence("SQ_EM_REF_ITEMS_ATTR_VALUES").IsCyclic();

            modelBuilder.HasSequence("SQ_EM_REFS").IsCyclic();

            modelBuilder.HasSequence("SQ_EMP_CARD_BANK").IsCyclic();

            modelBuilder.HasSequence("SQ_EMP_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_EMP_GROUP_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_EMP_MOVING_PAR").IsCyclic();

            modelBuilder.HasSequence("SQ_EMP_PICTURE").IsCyclic();

            modelBuilder.HasSequence("SQ_EMP_SAL_ITEM").IsCyclic();

            modelBuilder.HasSequence("SQ_EMPLOYEE").IsCyclic();

            modelBuilder.HasSequence("SQ_EMPLOYEE_ADDRESS").IsCyclic();

            modelBuilder.HasSequence("SQ_EMPLOYEE_BOOK").IsCyclic();

            modelBuilder.HasSequence("SQ_EMPLOYEE_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_EMPLOYEE_DOCUMENT").IsCyclic();

            modelBuilder.HasSequence("SQ_EMPLOYEE_EDUCATION").IsCyclic();

            modelBuilder.HasSequence("SQ_EMPLOYEE_FAMILY").IsCyclic();

            modelBuilder.HasSequence("SQ_EMPLOYEE_IMAGE").IsCyclic();

            modelBuilder.HasSequence("SQ_EMPLOYEE_INFO").IsCyclic();

            modelBuilder.HasSequence("SQ_EMPLOYEE_LANGUAGE").IsCyclic();

            modelBuilder.HasSequence("SQ_EMPLOYEE_MILITARY").IsCyclic();

            modelBuilder.HasSequence("SQ_EMPLOYEE_MOVING").IsCyclic();

            modelBuilder.HasSequence("SQ_EMPLOYEE_PARM").IsCyclic();

            modelBuilder.HasSequence("SQ_EMPLOYEE_PHONE").IsCyclic();

            modelBuilder.HasSequence("SQ_EMPTY").IsCyclic();

            modelBuilder.HasSequence("SQ_EMPTY_DATE").IsCyclic();

            modelBuilder.HasSequence("SQ_ENDORSEMENT_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_ENT_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_ENT_DESC_DATE").IsCyclic();

            modelBuilder.HasSequence("SQ_ENT_FOR_ORDER").IsCyclic();

            modelBuilder.HasSequence("SQ_ENT_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_ENT_HIER").IsCyclic();

            modelBuilder.HasSequence("SQ_ENT_OWNERS_GRP").IsCyclic();

            modelBuilder.HasSequence("SQ_ENT_PARAM_GIVEN").IsCyclic();

            modelBuilder.HasSequence("SQ_ENT_PARAM_ITEM").IsCyclic();

            modelBuilder.HasSequence("SQ_ENT_PARAM_VALUE").IsCyclic();

            modelBuilder.HasSequence("SQ_ENT_PARAMETER").IsCyclic();

            modelBuilder.HasSequence("SQ_ENT_PARAMS").IsCyclic();

            modelBuilder.HasSequence("SQ_ENTERPRISE").IsCyclic();

            modelBuilder.HasSequence("SQ_ERROR_LOG").IsCyclic();

            modelBuilder.HasSequence("SQ_ESTABLISHMENT").IsCyclic();

            modelBuilder.HasSequence("SQ_ETR_CARGO_FEATURE").IsCyclic();

            modelBuilder.HasSequence("SQ_ETR_CARRY_DENY_CODE").IsCyclic();

            modelBuilder.HasSequence("SQ_ETR_CARRY_PLAN_D").IsCyclic();

            modelBuilder.HasSequence("SQ_ETR_CONTRACTOR_ROLE").IsCyclic();

            modelBuilder.HasSequence("SQ_ETR_COUNTRY").IsCyclic();

            modelBuilder.HasSequence("SQ_ETR_GOODS_GNG").IsCyclic();

            modelBuilder.HasSequence("SQ_ETR_INPUT_METHOD").IsCyclic();

            modelBuilder.HasSequence("SQ_ETR_PACKING_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_ETR_RW").IsCyclic();

            modelBuilder.HasSequence("SQ_ETR_RW_DIRECTION").IsCyclic();

            modelBuilder.HasSequence("SQ_ETR_RW_STATION").IsCyclic();

            modelBuilder.HasSequence("SQ_ETR_SENDING_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_ETR_STATLOAD").IsCyclic();

            modelBuilder.HasSequence("SQ_ETR_WADDLE_CNT").IsCyclic();

            modelBuilder.HasSequence("SQ_ETR_WADDLE_POINT").IsCyclic();

            modelBuilder.HasSequence("SQ_ETR_WATERPORT").IsCyclic();

            modelBuilder.HasSequence("SQ_EVENT").IsCyclic();

            modelBuilder.HasSequence("SQ_EVENT_HANDLER_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_EVENT_ROUTE_OPTIONS").IsCyclic();

            modelBuilder.HasSequence("SQ_EVENT_SUBSCRIPTION").IsCyclic();

            modelBuilder.HasSequence("SQ_EVENT_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_EVENT_TYPE_IDLE_LINK").IsCyclic();

            modelBuilder.HasSequence("SQ_EVENT_TYPE_SUBSCRIPTION").IsCyclic();

            modelBuilder.HasSequence("SQ_EVENT_TYPE_WORK_LINK").IsCyclic();

            modelBuilder.HasSequence("SQ_EVENT_WORK_KIND").IsCyclic();

            modelBuilder.HasSequence("SQ_EXCEPT_DATE").IsCyclic();

            modelBuilder.HasSequence("SQ_EXCHANGE").IsCyclic();

            modelBuilder.HasSequence("SQ_EXCHANGE_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_EXP_ART_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_EXP_ART_NORM").IsCyclic();

            modelBuilder.HasSequence("SQ_EXP_ART_ORG").IsCyclic();

            modelBuilder.HasSequence("SQ_EXP_PLACE_DIR").IsCyclic();

            modelBuilder.HasSequence("SQ_EXP_PLACE_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_EXPENSES_PLACE").IsCyclic();

            modelBuilder.HasSequence("SQ_EXPORT_FORMAT").IsCyclic();

            modelBuilder.HasSequence("SQ_EXPORT_META").IsCyclic();

            modelBuilder.HasSequence("SQ_EXPORT_REP").IsCyclic();

            modelBuilder.HasSequence("SQ_EXPORT_TASK").IsCyclic();

            modelBuilder.HasSequence("SQ_EXTERNAL_DOC_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_FACILITY").IsCyclic();

            modelBuilder.HasSequence("SQ_FACILITY_CHILDREN").IsCyclic();

            modelBuilder.HasSequence("SQ_FACTOR_DOCTP_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_FACTOR_PERIOD").IsCyclic();

            modelBuilder.HasSequence("SQ_FBI_CMD").IsCyclic();

            modelBuilder.HasSequence("SQ_FBI_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_FBI_GROUP_META").IsCyclic();

            modelBuilder.HasSequence("SQ_FBI_META").IsCyclic();

            modelBuilder.HasSequence("SQ_FBI_OWNER").IsCyclic();

            modelBuilder.HasSequence("SQ_FBI_OWNER_CMD").IsCyclic();

            modelBuilder.HasSequence("SQ_FBI_REPL_INFO").IsCyclic();

            modelBuilder.HasSequence("SQ_FBI_REPL_LOG").IsCyclic();

            modelBuilder.HasSequence("SQ_FBI_RESP_ORG").IsCyclic();

            modelBuilder.HasSequence("SQ_FBI_WORK").IsCyclic();

            modelBuilder.HasSequence("SQ_FDS_CRITERIA").IsCyclic();

            modelBuilder.HasSequence("SQ_FDS_EVAL_MODE").IsCyclic();

            modelBuilder.HasSequence("SQ_FDS_FACTOR").IsCyclic();

            modelBuilder.HasSequence("SQ_FDS_FACTOR_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_FDS_FACTOR_GIVEN").IsCyclic();

            modelBuilder.HasSequence("SQ_FDS_ITEM_GIVEN").IsCyclic();

            modelBuilder.HasSequence("SQ_FDS_SUBJ_ITEM").IsCyclic();

            modelBuilder.HasSequence("SQ_FDS_SUBJ_ITEM_VAL").IsCyclic();

            modelBuilder.HasSequence("SQ_FDS_SUBJECT").IsCyclic();

            modelBuilder.HasSequence("SQ_FDS_SUBJECT_GIVEN").IsCyclic();

            modelBuilder.HasSequence("SQ_FDS_VALUE").IsCyclic();

            modelBuilder.HasSequence("SQ_FILLING_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_FILLING_STATION").IsCyclic();

            modelBuilder.HasSequence("SQ_FILLING_TEST").IsCyclic();

            modelBuilder.HasSequence("SQ_FILLING_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_FINANCE_RATE").IsCyclic();

            modelBuilder.HasSequence("SQ_FIXED_SENSOR").IsCyclic();

            modelBuilder.HasSequence("SQ_FLOWMETER").IsCyclic();

            modelBuilder.HasSequence("SQ_FLOWMETER_CHECK").IsCyclic();

            modelBuilder.HasSequence("SQ_FLOWMETER_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_FLOWMETER_IN").IsCyclic();

            modelBuilder.HasSequence("SQ_FLOWMETER_OUT").IsCyclic();

            modelBuilder.HasSequence("SQ_FLOWMETER_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_FOX").IsCyclic();

            modelBuilder.HasSequence("SQ_FS_PERIOD_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_FUCKING_FOX").IsCyclic();

            modelBuilder.HasSequence("SQ_FUELLING_NOZZLE").IsCyclic();

            modelBuilder.HasSequence("SQ_GAI_TRANSPORT_REG").IsCyclic();

            modelBuilder.HasSequence("SQ_GDS_CERT_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_GDS_CERT_ISSUED").IsCyclic();

            modelBuilder.HasSequence("SQ_GDS_CERT_MI").IsCyclic();

            modelBuilder.HasSequence("SQ_GDS_CLASS_COEFF").IsCyclic();

            modelBuilder.HasSequence("SQ_GDS_OWNERSHIP").IsCyclic();

            modelBuilder.HasSequence("SQ_GDS_PARAMETER").IsCyclic();

            modelBuilder.HasSequence("SQ_GDS_PRICE").IsCyclic();

            modelBuilder.HasSequence("SQ_GDS_PRICE_ENT").IsCyclic();

            modelBuilder.HasSequence("SQ_GDS_PRICE_FDS").IsCyclic();

            modelBuilder.HasSequence("SQ_GDS_PRICE_PERIOD").IsCyclic();

            modelBuilder.HasSequence("SQ_GDS_PROPERTY").IsCyclic();

            modelBuilder.HasSequence("SQ_GDS_STANDARD").IsCyclic();

            modelBuilder.HasSequence("SQ_GDS_STROKE_CODE").IsCyclic();

            modelBuilder.HasSequence("SQ_GDS_TYPE_PROPERTY").IsCyclic();

            modelBuilder.HasSequence("SQ_GOGA").IsCyclic();

            modelBuilder.HasSequence("SQ_GOODS").IsCyclic();

            modelBuilder.HasSequence("SQ_GOODS_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_GOODS_DESC_DATE").IsCyclic();

            modelBuilder.HasSequence("SQ_GOODS_ENT").IsCyclic();

            modelBuilder.HasSequence("SQ_GOODS_EXCISE").IsCyclic();

            modelBuilder.HasSequence("SQ_GOODS_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_GOODS_GROUP_CNT").IsCyclic();

            modelBuilder.HasSequence("SQ_GOODS_GROUP_RESP").IsCyclic();

            modelBuilder.HasSequence("SQ_GOODS_GTD_NUMBER").IsCyclic();

            modelBuilder.HasSequence("SQ_GOODS_HIERARCHY").IsCyclic();

            modelBuilder.HasSequence("SQ_GOODS_REPLACE").IsCyclic();

            modelBuilder.HasSequence("SQ_GOODS_SET").IsCyclic();

            modelBuilder.HasSequence("SQ_GOODS_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_GOODS_UNION").IsCyclic();

            modelBuilder.HasSequence("SQ_GROUP_CATEGORY").IsCyclic();

            modelBuilder.HasSequence("SQ_GROUP_DEPENDENCE").IsCyclic();

            modelBuilder.HasSequence("SQ_GROUP_HIERARCHY").IsCyclic();

            modelBuilder.HasSequence("SQ_GROUP_STRUCTURE").IsCyclic();

            modelBuilder.HasSequence("SQ_GROUP_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_GSM_RATE").IsCyclic();

            modelBuilder.HasSequence("SQ_GSM_RATE_COEFF").IsCyclic();

            modelBuilder.HasSequence("SQ_GSM_RATE_DATE").IsCyclic();

            modelBuilder.HasSequence("SQ_GSM_RATE_VAL").IsCyclic();

            modelBuilder.HasSequence("SQ_HEALTH_INSURANCE").IsCyclic();

            modelBuilder.HasSequence("SQ_HOLIDAY").IsCyclic();

            modelBuilder.HasSequence("SQ_HOLIDAY_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_HOLIDAY_WORK").IsCyclic();

            modelBuilder.HasSequence("SQ_ID_COPIER").IsCyclic();

            modelBuilder.HasSequence("SQ_IDLE_TIME_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_IMPORT_BANK_EXTRACTION").IsCyclic();

            modelBuilder.HasSequence("SQ_IMPORT_BUF_MODEL").IsCyclic();

            modelBuilder.HasSequence("SQ_IMPORT_IN_PORDER").IsCyclic();

            modelBuilder.HasSequence("SQ_IMPORT_OBJECT").IsCyclic();

            modelBuilder.HasSequence("SQ_IMPORT_OBJECT_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_IMPORT_RAW_MODEL").IsCyclic();

            modelBuilder.HasSequence("SQ_INDEPENDENT_SCHEME").IsCyclic();

            modelBuilder.HasSequence("SQ_INSTRUCTION_PAR").IsCyclic();

            modelBuilder.HasSequence("SQ_INVEST").IsCyclic();

            modelBuilder.HasSequence("SQ_INVEST_CONTRACTOR").IsCyclic();

            modelBuilder.HasSequence("SQ_INVEST_DIR_SECTION").IsCyclic();

            modelBuilder.HasSequence("SQ_INVEST_DISCRIM").IsCyclic();

            modelBuilder.HasSequence("SQ_INVEST_OBLIGATION").IsCyclic();

            modelBuilder.HasSequence("SQ_INVEST_PLAN_AMOUNT").IsCyclic();

            modelBuilder.HasSequence("SQ_INVEST_PROJECT").IsCyclic();

            modelBuilder.HasSequence("SQ_INVEST_STATUS").IsCyclic();

            modelBuilder.HasSequence("SQ_INVOICE_NUM").IsCyclic();

            modelBuilder.HasSequence("SQ_INVOICE_NUM_HOLE").IsCyclic();

            modelBuilder.HasSequence("SQ_INVOICE_NUM_RANGE").IsCyclic();

            modelBuilder.HasSequence("SQ_INVOICE_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_AO_DD").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_AO_DELIV_DATE_GDS").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_AO_EXCLUDE_GDS").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_AO_GDS_PARAM").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_AO_LOG").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_AO_PARAM").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_COMMISSION_MEMBERS").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_COMP_PERSONS").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_DEVICE_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_DIADOC_DOC").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_DIADOC_LOG").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_DIADOC_LOGS_TEST").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_ECHEQUE_ANSWERS").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_EMP_PERS_DEVICE").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_EMP_STUDY").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_HARDWARE_PARAMS").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_INBOUND_DOC_DIADOC").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_INET_TARIF").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_LICARDS_CARDS").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_MEDIA_AZS").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_MEDIA_AZS_GDS").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_MEDIA_RESP_GDS").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_MEDIA_RESP_LOG").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_PERS_DEVICE").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_POSITION_STUDY").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_POWER_TARIF").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_SD_CATEGORY").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_SD_COMPANY").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_SD_GRP_LINK").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_SD_GRP_OBJ").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_SD_OBJECT").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_SD_SERVICE").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_SD_SLA").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_SEPARATE_SUBDIV_DIADOC").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_STUDY").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_STUDY_COMM").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_STUDY_TASK").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_STUDY_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_TIPS_CHECKIN").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_UNIFORM_DEMAND_LINK").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_UNIFORM_SIZE").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_UNIFORM_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_WEATHER_JOURNAL").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_WEATHER_JOURNAL_PLACE").IsCyclic();

            modelBuilder.HasSequence("SQ_IRIS_XLSTOOTRS_LOGS_TEST").IsCyclic();

            modelBuilder.HasSequence("SQ_IRISOR_LIMIT").IsCyclic();

            modelBuilder.HasSequence("SQ_IRISOR_PROGRAM").IsCyclic();

            modelBuilder.HasSequence("SQ_IRISOR_PROGRAM_GDS").IsCyclic();

            modelBuilder.HasSequence("SQ_IRISOR_RING").IsCyclic();

            modelBuilder.HasSequence("SQ_IRISOR_UID_PAN").IsCyclic();

            modelBuilder.HasSequence("SQ_IRISOR_USER").IsCyclic();

            modelBuilder.HasSequence("SQ_ISSUE_SHEET_PERM").IsCyclic();

            modelBuilder.HasSequence("SQ_JOB_ERR_MESSAGE").IsCyclic();

            modelBuilder.HasSequence("SQ_JOB_MESSAGE").IsCyclic();

            modelBuilder.HasSequence("SQ_JOB_PROCESS").IsCyclic();

            modelBuilder.HasSequence("SQ_JOB_TITLE").IsCyclic();

            modelBuilder.HasSequence("SQ_JOB_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_JR_TEMPLATE").IsCyclic();

            modelBuilder.HasSequence("SQ_KAZS_CHEQUE_PARAMS").IsCyclic();

            modelBuilder.HasSequence("SQ_KAZS_FOO").IsCyclic();

            modelBuilder.HasSequence("SQ_KAZS_FOO_CONNECTION").IsCyclic();

            modelBuilder.HasSequence("SQ_KAZS_FOO_ENT").IsCyclic();

            modelBuilder.HasSequence("SQ_KAZS_FOO_ENT_PARAM_VALUE").IsCyclic();

            modelBuilder.HasSequence("SQ_KAZS_FOO_PARAM").IsCyclic();

            modelBuilder.HasSequence("SQ_KAZS_FOO_PARAM_DEFAULT").IsCyclic();

            modelBuilder.HasSequence("SQ_KAZS_FOO_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_KAZS_PARAM").IsCyclic();

            modelBuilder.HasSequence("SQ_KAZS_PARAM_ENUM").IsCyclic();

            modelBuilder.HasSequence("SQ_KAZS_TEMPLATE").IsCyclic();

            modelBuilder.HasSequence("SQ_KKM_DATECS").IsCyclic();

            modelBuilder.HasSequence("SQ_KLS_LANG").IsCyclic();

            modelBuilder.HasSequence("SQ_KLS_LANG_TEXT").IsCyclic();

            modelBuilder.HasSequence("SQ_KLS_ORIG_SRC").IsCyclic();

            modelBuilder.HasSequence("SQ_KLS_ORIG_TEXT").IsCyclic();

            modelBuilder.HasSequence("SQ_KLS_SRC").IsCyclic();

            modelBuilder.HasSequence("SQ_KLS_TAG").IsCyclic();

            modelBuilder.HasSequence("SQ_KLS_VAL_TEXT").IsCyclic();

            modelBuilder.HasSequence("SQ_KOD_FORING_RULES").IsCyclic();

            modelBuilder.HasSequence("SQ_KRNLMSG").IsCyclic();

            modelBuilder.HasSequence("SQ_LEAVE").IsCyclic();

            modelBuilder.HasSequence("SQ_LEAVE_BREAK").IsCyclic();

            modelBuilder.HasSequence("SQ_LEAVE_BREAK_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_LEAVE_POS").IsCyclic();

            modelBuilder.HasSequence("SQ_LEAVE_PREV").IsCyclic();

            modelBuilder.HasSequence("SQ_LEAVE_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_LEAVE_UPTIME_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_LIMIT_IRIS_MAT");

            modelBuilder.HasSequence("SQ_LIMIT_IRIS_MAT_I");

            modelBuilder.HasSequence("SQ_LIMIT_IRIS_MOVE");

            modelBuilder.HasSequence("SQ_LIMIT_IRIS_SUPP");

            modelBuilder.HasSequence("SQ_LINE_TYPE_STORNO_COL").IsCyclic();

            modelBuilder.HasSequence("SQ_LINK_CODEM_DEPARTMENT").IsCyclic();

            modelBuilder.HasSequence("SQ_LINK_DEM_I_SUPP_PLAN").IsCyclic();

            modelBuilder.HasSequence("SQ_LINK_REQUEST_DEMAND").IsCyclic();

            modelBuilder.HasSequence("SQ_LINK_ROUTE_IRIS_DEMAND").IsCyclic();

            modelBuilder.HasSequence("SQ_LINK_ROUTE_IRIS_REQUEST").IsCyclic();

            modelBuilder.HasSequence("SQ_LINK_UNIFORM_POSITION").IsCyclic();

            modelBuilder.HasSequence("SQ_LOAD_ON_AXIS").IsCyclic();

            modelBuilder.HasSequence("SQ_LOCKING_STATE").IsCyclic();

            modelBuilder.HasSequence("SQ_LOSS_NORM_MISCALC").IsCyclic();

            modelBuilder.HasSequence("SQ_LOSSES_OPERATION").IsCyclic();

            modelBuilder.HasSequence("SQ_LOSSES_PERIOD").IsCyclic();

            modelBuilder.HasSequence("SQ_LOSSES_RATE").IsCyclic();

            modelBuilder.HasSequence("SQ_LOV_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_MAP").IsCyclic();

            modelBuilder.HasSequence("SQ_MAT_INV_LIST_COMM").IsCyclic();

            modelBuilder.HasSequence("SQ_MEAS_CORR_COEFF").IsCyclic();

            modelBuilder.HasSequence("SQ_MEASURE_CONV").IsCyclic();

            modelBuilder.HasSequence("SQ_MEASURE_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_MEASURE_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_MESSAGE").IsCyclic();

            modelBuilder.HasSequence("SQ_METROLOGICAL_FACTORS").IsCyclic();

            modelBuilder.HasSequence("SQ_MK_WORK_ORDER_SP").IsCyclic();

            modelBuilder.HasSequence("SQ_MOTOR_DISTANCE").IsCyclic();

            modelBuilder.HasSequence("SQ_MOVE_PLANNING_GRP").IsCyclic();

            modelBuilder.HasSequence("SQ_NATURE_LIST_NUM").IsCyclic();

            modelBuilder.HasSequence("SQ_NDS_CONDITION").IsCyclic();

            modelBuilder.HasSequence("SQ_NDS_CONDITION_PERIOD").IsCyclic();

            modelBuilder.HasSequence("SQ_NDS_METHOD").IsCyclic();

            modelBuilder.HasSequence("SQ_NMCL_ASSORTMENT").IsCyclic();

            modelBuilder.HasSequence("SQ_NMCL_ASSORTMENT_I").IsCyclic();

            modelBuilder.HasSequence("SQ_NMCL_MATRIX").IsCyclic();

            modelBuilder.HasSequence("SQ_NMCL_MATRIX_CNT").IsCyclic();

            modelBuilder.HasSequence("SQ_NMCL_MATRIX_I").IsCyclic();

            modelBuilder.HasSequence("SQ_NMCL_MATRIX_I_DELETED").IsCyclic();

            modelBuilder.HasSequence("SQ_NODE_POUR").IsCyclic();

            modelBuilder.HasSequence("SQ_NOZZLE_BY_SECTION").IsCyclic();

            modelBuilder.HasSequence("SQ_NSWERS").IsCyclic();

            modelBuilder.HasSequence("SQ_OI_AGG_CALC").IsCyclic();

            modelBuilder.HasSequence("SQ_OI_AGG_CALC_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_OIL_DEPOSIT").IsCyclic();

            modelBuilder.HasSequence("SQ_OIL_NODE").IsCyclic();

            modelBuilder.HasSequence("SQ_OIL_OWNERSHIP_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_OIL_SUPPLY_CATEGORY").IsCyclic();

            modelBuilder.HasSequence("SQ_OIL_SUPPLY_CONDITION").IsCyclic();

            modelBuilder.HasSequence("SQ_OIL_SUPPLY_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_OKATO").IsCyclic();

            modelBuilder.HasSequence("SQ_OKATO_CNT").IsCyclic();

            modelBuilder.HasSequence("SQ_OPERAND_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_OPERATIONS").IsCyclic();

            modelBuilder.HasSequence("SQ_ORDER_OARS").IsCyclic();

            modelBuilder.HasSequence("SQ_ORG_INSURANCE").IsCyclic();

            modelBuilder.HasSequence("SQ_ORG_PRICE_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_ORG_STATE").IsCyclic();

            modelBuilder.HasSequence("SQ_ORG_STATE_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_ORG_TAX").IsCyclic();

            modelBuilder.HasSequence("SQ_ORGANIZATION").IsCyclic();

            modelBuilder.HasSequence("SQ_ORGANIZATION_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_OUT_INVOICE_AGG").IsCyclic();

            modelBuilder.HasSequence("SQ_OUT_INVOICE_AGG_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_OUT_ORDER_OS_NUM").IsCyclic();

            modelBuilder.HasSequence("SQ_OUT_ORDER_OS_S").IsCyclic();

            modelBuilder.HasSequence("SQ_OUT_ORDER_SEND").IsCyclic();

            modelBuilder.HasSequence("SQ_OUT_PARTY_AGG").IsCyclic();

            modelBuilder.HasSequence("SQ_OUT_PORDER_CORR").IsCyclic();

            modelBuilder.HasSequence("SQ_OUT_WBILL_CARD").IsCyclic();

            modelBuilder.HasSequence("SQ_OUT_WBILL_MO_OS_EX").IsCyclic();

            modelBuilder.HasSequence("SQ_OUT_WBILL_PASS").IsCyclic();

            modelBuilder.HasSequence("SQ_OUT_WBILL_RAW").IsCyclic();

            modelBuilder.HasSequence("SQ_OUT_WBILL_RW_BASE").IsCyclic();

            modelBuilder.HasSequence("SQ_OUT_WBILL_RW_MO").IsCyclic();

            modelBuilder.HasSequence("SQ_OUT_WBILL_RW_SEAL").IsCyclic();

            modelBuilder.HasSequence("SQ_OUT_WBILL_WA_OS_A").IsCyclic();

            modelBuilder.HasSequence("SQ_OVERALL_ISSUE").IsCyclic();

            modelBuilder.HasSequence("SQ_OVERALL_ISSUE_RATE").IsCyclic();

            modelBuilder.HasSequence("SQ_PARCEL").IsCyclic();

            modelBuilder.HasSequence("SQ_PARCEL_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_PARCEL_FLOW").IsCyclic();

            modelBuilder.HasSequence("SQ_PARCEL_ID_SET").IsCyclic();

            modelBuilder.HasSequence("SQ_PARCEL_NETWORK").IsCyclic();

            modelBuilder.HasSequence("SQ_PENSIONER").IsCyclic();

            modelBuilder.HasSequence("SQ_PERIOD_SALARY").IsCyclic();

            modelBuilder.HasSequence("SQ_PERS_MOVE_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_PERSON_ACCESS_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_PERSON_VISA").IsCyclic();

            modelBuilder.HasSequence("SQ_PERSONNEL_ACCESS").IsCyclic();

            modelBuilder.HasSequence("SQ_PERSONNEL_BOOK").IsCyclic();

            modelBuilder.HasSequence("SQ_PERSONNEL_BOOK_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_PERSONNEL_BOOK_VAL").IsCyclic();

            modelBuilder.HasSequence("SQ_PERSONNEL_CHANGE").IsCyclic();

            modelBuilder.HasSequence("SQ_PETROIL_PUMP").IsCyclic();

            modelBuilder.HasSequence("SQ_PIPELINE").IsCyclic();

            modelBuilder.HasSequence("SQ_PIPELINE_VOLUME").IsCyclic();

            modelBuilder.HasSequence("SQ_PLAN_CORR_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_PLAN_OWNERS_GRP").IsCyclic();

            modelBuilder.HasSequence("SQ_PLANGROUP_DIR").IsCyclic();

            modelBuilder.HasSequence("SQ_PLANGROUP_GRP_DIR").IsCyclic();

            modelBuilder.HasSequence("SQ_PLANGROUP_TRT").IsCyclic();

            modelBuilder.HasSequence("SQ_PLANT").IsCyclic();

            modelBuilder.HasSequence("SQ_PLASTIC_CARD").IsCyclic();

            modelBuilder.HasSequence("SQ_PLASTIC_CARD_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_POSITION").IsCyclic();

            modelBuilder.HasSequence("SQ_POSITION_CATEGORY").IsCyclic();

            modelBuilder.HasSequence("SQ_POSITION_PERS_BOOK").IsCyclic();

            modelBuilder.HasSequence("SQ_POSITION_QUALIFICATION").IsCyclic();

            modelBuilder.HasSequence("SQ_POSITION_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_POUR_TIME").IsCyclic();

            modelBuilder.HasSequence("SQ_POURING").IsCyclic();

            modelBuilder.HasSequence("SQ_POURING_DATE").IsCyclic();

            modelBuilder.HasSequence("SQ_PRICE_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_PRICE_GROUP_ENT").IsCyclic();

            modelBuilder.HasSequence("SQ_PRICE_GROUP_GOODS").IsCyclic();

            modelBuilder.HasSequence("SQ_PRICE_GROUP_PERIOD").IsCyclic();

            modelBuilder.HasSequence("SQ_PRICE_GROUP_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_PRICE_GRP_RELATION").IsCyclic();

            modelBuilder.HasSequence("SQ_PRICE_HIER").IsCyclic();

            modelBuilder.HasSequence("SQ_PRICE_HIER_ENT").IsCyclic();

            modelBuilder.HasSequence("SQ_PRICE_REQUEST").IsCyclic();

            modelBuilder.HasSequence("SQ_PRICE_REQUEST_WEB").IsCyclic();

            modelBuilder.HasSequence("SQ_PRICE_RESOURCE_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_PRICE_ROUND_RULE").IsCyclic();

            modelBuilder.HasSequence("SQ_PRICE_SYSTEM_GOODS").IsCyclic();

            modelBuilder.HasSequence("SQ_PRICE_TUNE_RULE").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_BOOKMARK").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_CROSS_CELL").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_CROSS_COL").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_CTL_SYNTAX").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_DATA").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_DEFAULT").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_DESCRIPTION").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_DOC").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_DOC_CUST").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_DOCCUST_LNK").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_GRP_PARAM").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_LOG_REPORT").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_PARAMETER").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_PRINT_CUST").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_PRINTCUST_LNK").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_PROC").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_REP_COLUMNS").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_SEL_PARAM").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_SEL_PARAM_VAL").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_SEL_STMT").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_SERV_PAR_LIST").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_SERV_PARAM").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_SERV_PARAM_VAL").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_TMPL_FILE").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_TMPLFILE_LNK").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_TOOL").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_TOOL_CTL").IsCyclic();

            modelBuilder.HasSequence("SQ_PRN_VISUAL_RULE").IsCyclic();

            modelBuilder.HasSequence("SQ_PROD_GOODS").IsCyclic();

            modelBuilder.HasSequence("SQ_PROD_PLANNING_GRP").IsCyclic();

            modelBuilder.HasSequence("SQ_PRODUCIBLE_GOODS").IsCyclic();

            modelBuilder.HasSequence("SQ_PRODUCTION_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_PROFILE_DENSITY").IsCyclic();

            modelBuilder.HasSequence("SQ_PROFILE_TEMP").IsCyclic();

            modelBuilder.HasSequence("SQ_PROJECT_ITEM").IsCyclic();

            modelBuilder.HasSequence("SQ_PROJECT_ITEM_AMOUNT").IsCyclic();

            modelBuilder.HasSequence("SQ_PROJECT_ITEM_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_PROJECT_ITEM_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_PROJECT_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_PROMO_ACTION").IsCyclic();

            modelBuilder.HasSequence("SQ_PROTOCOL_GUILT_COM").IsCyclic();

            modelBuilder.HasSequence("SQ_PST_PISMO").IsCyclic();

            modelBuilder.HasSequence("SQ_PST_REESTR_PISEM").IsCyclic();

            modelBuilder.HasSequence("SQ_PURCHASE_BOOK_BASE").IsCyclic();

            modelBuilder.HasSequence("SQ_PURCHASE_BOOK_RULE").IsCyclic();

            modelBuilder.HasSequence("SQ_QUALIFICATION").IsCyclic();

            modelBuilder.HasSequence("SQ_R_TABLE_ORDER").IsCyclic();

            modelBuilder.HasSequence("SQ_R3").IsCyclic();

            modelBuilder.HasSequence("SQ_RAILWAY").IsCyclic();

            modelBuilder.HasSequence("SQ_RAILWAY_STATION").IsCyclic();

            modelBuilder.HasSequence("SQ_RATE_OF_SAL").IsCyclic();

            modelBuilder.HasSequence("SQ_RATE_OF_SAL_POSITION").IsCyclic();

            modelBuilder.HasSequence("SQ_RATE_OF_SAL_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_READER").IsCyclic();

            modelBuilder.HasSequence("SQ_READER_LOG").IsCyclic();

            modelBuilder.HasSequence("SQ_READER_PLACE").IsCyclic();

            modelBuilder.HasSequence("SQ_READER_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_READING_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_RECEIPT_DOC_REST").IsCyclic();

            modelBuilder.HasSequence("SQ_RECEIPT_DOC_SAP").IsCyclic();

            modelBuilder.HasSequence("SQ_RECEIPT_DOC_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_REF_DW").IsCyclic();

            modelBuilder.HasSequence("SQ_REF_OBJ_PARAM").IsCyclic();

            modelBuilder.HasSequence("SQ_REF_OBJ_PARAM_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_REF_OBJ_USE").IsCyclic();

            modelBuilder.HasSequence("SQ_REF_OBJECT").IsCyclic();

            modelBuilder.HasSequence("SQ_REGION").IsCyclic();

            modelBuilder.HasSequence("SQ_REGION_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_REGION_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_REGISTRATION_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_REPLACE_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_REQ_NUMBER").IsCyclic();

            modelBuilder.HasSequence("SQ_REQUEST_DEMAND_OTRS_LOG").IsCyclic();

            modelBuilder.HasSequence("SQ_RESOURCE_GROUP_REPL").IsCyclic();

            modelBuilder.HasSequence("SQ_RESPONS_OBJECT").IsCyclic();

            modelBuilder.HasSequence("SQ_RESPONS_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_RESSYMB_TOPAZ_I").IsCyclic();

            modelBuilder.HasSequence("SQ_ROBJ_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_ROBJ_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_ROUTE").IsCyclic();

            modelBuilder.HasSequence("SQ_ROUTE_CNT").IsCyclic();

            modelBuilder.HasSequence("SQ_ROUTE_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_ROUTE_IRIS_CAR").IsCyclic();

            modelBuilder.HasSequence("SQ_ROUTE_IRIS_CAR_PARAM_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_ROUTE_IRIS_CAR_PARAMS").IsCyclic();

            modelBuilder.HasSequence("SQ_ROUTE_IRIS_POINT").IsCyclic();

            modelBuilder.HasSequence("SQ_ROUTE_IRIS_PRICE").IsCyclic();

            modelBuilder.HasSequence("SQ_RUS_MONTH").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_ATTRIBUTE_PRICE").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_COEFF").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_COMM_OPER_ALLOW").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_COMMERCIAL_OPER").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_DISCOUNT_FDS").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_DISTANCE").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_GDS_IN_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_GOODS").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_GOODS_CLASS").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_GOODS_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_GOODS_HIERARCHY").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_GOODS_PARAM").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_GOODS_PROPERTY").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_LOAD_PLACE").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_LOAD_PLACE_OPER").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_LOAD_PLACE_WAIT").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_PAYCODE").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_PAYCODE_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_PLAN_TRUCK").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_PLAN_TRUCK_GRUPPA").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_PLAN_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_RASCH_PROM").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_RASCH_SET").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_TARIF_PAY_COND").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_TRUCK_OPER").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_WAIT_PERP").IsCyclic();

            modelBuilder.HasSequence("SQ_RW_WAIT_REASON").IsCyclic();

            modelBuilder.HasSequence("SQ_RWGOODS_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_SACK_EMPLOYEE_MOVING").IsCyclic();

            modelBuilder.HasSequence("SQ_SAL_CALC_RESULT").IsCyclic();

            modelBuilder.HasSequence("SQ_SAL_CALC_RESULT_TEXT").IsCyclic();

            modelBuilder.HasSequence("SQ_SAL_CALC_RESULT_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_SAL_CALC_SCRIPT").IsCyclic();

            modelBuilder.HasSequence("SQ_SAL_ITEM").IsCyclic();

            modelBuilder.HasSequence("SQ_SAL_ITEM_CALC").IsCyclic();

            modelBuilder.HasSequence("SQ_SAL_ITEM_FORMULA").IsCyclic();

            modelBuilder.HasSequence("SQ_SAL_ITEM_SIGN").IsCyclic();

            modelBuilder.HasSequence("SQ_SAL_ITEM_SIGN_POS").IsCyclic();

            modelBuilder.HasSequence("SQ_SAL_ITEM_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_SAL_USER").IsCyclic();

            modelBuilder.HasSequence("SQ_SAP_PARCEL").IsCyclic();

            modelBuilder.HasSequence("SQ_SB_ATSET_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_SB_GRP_UNIT").IsCyclic();

            modelBuilder.HasSequence("SQ_SB_GRPU_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_SCHEDULE_WORKS").IsCyclic();

            modelBuilder.HasSequence("SQ_SCHEDULE_WORKS_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_SCHEME_GOODS").IsCyclic();

            modelBuilder.HasSequence("SQ_SD_ATTACHMENT").IsCyclic();

            modelBuilder.HasSequence("SQ_SD_CATEGORY").IsCyclic();

            modelBuilder.HasSequence("SQ_SD_REASSIGNMENT").IsCyclic();

            modelBuilder.HasSequence("SQ_SD_REQUEST").IsCyclic();

            modelBuilder.HasSequence("SQ_SD_STATUS").IsCyclic();

            modelBuilder.HasSequence("SQ_SEASON").IsCyclic();

            modelBuilder.HasSequence("SQ_SEC_FORM_STATE").IsCyclic();

            modelBuilder.HasSequence("SQ_SEC_FORM_STATE_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_SEC_MOVE_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_SEC_MOVE_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_SECURITIES").IsCyclic();

            modelBuilder.HasSequence("SQ_SECURITIES_FORM").IsCyclic();

            modelBuilder.HasSequence("SQ_SECURITIES_STATE").IsCyclic();

            modelBuilder.HasSequence("SQ_SECURITIES_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_SELLING_GRP").IsCyclic();

            modelBuilder.HasSequence("SQ_SELLING_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_SEND_DEM_MAIL_HISTORY").IsCyclic();

            modelBuilder.HasSequence("SQ_SENSOR").IsCyclic();

            modelBuilder.HasSequence("SQ_SENSOR_CHECK").IsCyclic();

            modelBuilder.HasSequence("SQ_SENSOR_READING").IsCyclic();

            modelBuilder.HasSequence("SQ_SENSOR_T").IsCyclic();

            modelBuilder.HasSequence("SQ_SENSOR_TUNING").IsCyclic();

            modelBuilder.HasSequence("SQ_SENSOR_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_SERVER_INFO").IsCyclic();

            modelBuilder.HasSequence("SQ_SERVICE_CALC").IsCyclic();

            modelBuilder.HasSequence("SQ_SERVICE_CALC_ENT").IsCyclic();

            modelBuilder.HasSequence("SQ_SERVICE_CALC_FDS").IsCyclic();

            modelBuilder.HasSequence("SQ_SERVICE_CARD").IsCyclic();

            modelBuilder.HasSequence("SQ_SERVICE_PARAM").IsCyclic();

            modelBuilder.HasSequence("SQ_SERVICE_PARAM_CALC").IsCyclic();

            modelBuilder.HasSequence("SQ_SET_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_SET_QUANTITY").IsCyclic();

            modelBuilder.HasSequence("SQ_SHIFT_REPORT_CASH").IsCyclic();

            modelBuilder.HasSequence("SQ_SHIFT_REPORT_NOZ").IsCyclic();

            modelBuilder.HasSequence("SQ_SHIFT_REPORT_PERS").IsCyclic();

            modelBuilder.HasSequence("SQ_SHIFT_REPORT_PRINT").IsCyclic();

            modelBuilder.HasSequence("SQ_SHIFT_REPORT_SECT").IsCyclic();

            modelBuilder.HasSequence("SQ_SIGN_ACC").IsCyclic();

            modelBuilder.HasSequence("SQ_SIGN_ACC_DFLT").IsCyclic();

            modelBuilder.HasSequence("SQ_SIGN_DIR").IsCyclic();

            modelBuilder.HasSequence("SQ_SIGN_DIR_DFLT").IsCyclic();

            modelBuilder.HasSequence("SQ_SIGN_LEVEL").IsCyclic();

            modelBuilder.HasSequence("SQ_SIGN_LEVEL_ENT").IsCyclic();

            modelBuilder.HasSequence("SQ_SIGN_LEVEL_USER").IsCyclic();

            modelBuilder.HasSequence("SQ_SIGN_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_SM_USER").IsCyclic();

            modelBuilder.HasSequence("SQ_SM_USER_ACCESS").IsCyclic();

            modelBuilder.HasSequence("SQ_SPLAN_STATUS").IsCyclic();

            modelBuilder.HasSequence("SQ_STANDARD_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_STD_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_STD_PARAM_GDS").IsCyclic();

            modelBuilder.HasSequence("SQ_STD_PARAM_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_STD_PARAM_GROUP_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_STD_PARAMETER").IsCyclic();

            modelBuilder.HasSequence("SQ_STORAGE").IsCyclic();

            modelBuilder.HasSequence("SQ_STORAGE_ADD").IsCyclic();

            modelBuilder.HasSequence("SQ_STORAGE_CLEAN_LOSS").IsCyclic();

            modelBuilder.HasSequence("SQ_STORAGE_DEFAULT").IsCyclic();

            modelBuilder.HasSequence("SQ_STORAGE_DELTA").IsCyclic();

            modelBuilder.HasSequence("SQ_STORAGE_GOODS").IsCyclic();

            modelBuilder.HasSequence("SQ_STORAGE_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_STORAGE_LEVEL").IsCyclic();

            modelBuilder.HasSequence("SQ_STORAGE_LEVEL_M").IsCyclic();

            modelBuilder.HasSequence("SQ_STORAGE_OWNER").IsCyclic();

            modelBuilder.HasSequence("SQ_STORAGE_PARAM_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_STORAGE_PARAMS").IsCyclic();

            modelBuilder.HasSequence("SQ_STORAGE_PARK").IsCyclic();

            modelBuilder.HasSequence("SQ_STORAGE_PASS").IsCyclic();

            modelBuilder.HasSequence("SQ_STORAGE_POSITION").IsCyclic();

            modelBuilder.HasSequence("SQ_STORAGE_RAW").IsCyclic();

            modelBuilder.HasSequence("SQ_STORAGE_RAW_AGG").IsCyclic();

            modelBuilder.HasSequence("SQ_STORAGE_RAW_NOZ").IsCyclic();

            modelBuilder.HasSequence("SQ_STORAGE_REQUEST_STATUS").IsCyclic();

            modelBuilder.HasSequence("SQ_STORAGE_STAT_SHIFT_ALL_NIXX").IsCyclic();

            modelBuilder.HasSequence("SQ_STORAGE_STATUS").IsCyclic();

            modelBuilder.HasSequence("SQ_STORAGE_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_STREET").IsCyclic();

            modelBuilder.HasSequence("SQ_STREET_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_SUBJECT_OF_INV").IsCyclic();

            modelBuilder.HasSequence("SQ_SUM_DOCUMENT").IsCyclic();

            modelBuilder.HasSequence("SQ_SUMMARY_COEFF").IsCyclic();

            modelBuilder.HasSequence("SQ_SUP_GDS_REMAINS").IsCyclic();

            modelBuilder.HasSequence("SQ_SUPP_KPI_HIST").IsCyclic();

            modelBuilder.HasSequence("SQ_SUPP_TERMINAL").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_ACCESS").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_ACCESS_ORG").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_BUTTON").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_CON_NOTE").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_ENV_PARAM").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_ENV_VALUE").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_ENVIRONMENT").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_ERROR_CONSTRAINT").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_LEVEL").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_LEVEL_OWNER").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_MANAGER").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_PROPERTY").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_SERVER").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_STORE_WIN").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_UNIT").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_UNIT_ENV").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_UNIT_EVENT").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_UNIT_PROPERTY").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_UNIT_RUN").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_UNIT_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_USER").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_USER_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_USER_ENV").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_USER_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_USER_GROUP_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_USER_OTHER").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_USER_WIN").IsCyclic();

            modelBuilder.HasSequence("SQ_SYS_VISA").IsCyclic();

            modelBuilder.HasSequence("SQ_TABLE_ORDER").IsCyclic();

            modelBuilder.HasSequence("SQ_TABLE_REPL").IsCyclic();

            modelBuilder.HasSequence("SQ_TABLE_REPL_ERROR").IsCyclic();

            modelBuilder.HasSequence("SQ_TABLE_REPL_JOURNAL").IsCyclic();

            modelBuilder.HasSequence("SQ_TABLE_REPL_OPER").IsCyclic();

            modelBuilder.HasSequence("SQ_TANK_LEVEL").IsCyclic();

            modelBuilder.HasSequence("SQ_TANK_TRANSPORT").IsCyclic();

            modelBuilder.HasSequence("SQ_TANK_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_TARIF_CORR_COEFF").IsCyclic();

            modelBuilder.HasSequence("SQ_TARIF_SCHEME").IsCyclic();

            modelBuilder.HasSequence("SQ_TARIF_STAVKA").IsCyclic();

            modelBuilder.HasSequence("SQ_TASK_ACTION").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_ACCESS").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_BASE").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_BASE_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_BASE_METHOD").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_BONANZA").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_CODE").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_DISTRIBUTION").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_DOC").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_DOCTP_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_DOCUMENT").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_FACTOR").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_FACTOR_COLUMN").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_FACTOR_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_GROUP_DETAIL").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_GROUP_DOC").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_INSPECTION").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_INSPECTION_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_LEVEL").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_NAME").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_ON_PRICE").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_RATE").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_RATE_FDS").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_SCHEDULE").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_SUBJ_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_VAL_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_VALUE").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_WHERE_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_TAX_XML_TMP").IsCyclic();

            modelBuilder.HasSequence("SQ_TECH_PD_LIST_ADD").IsCyclic();

            modelBuilder.HasSequence("SQ_TELE_PATTERN").IsCyclic();

            modelBuilder.HasSequence("SQ_TELE_PATTERN_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_TEMP_SENSOR_TUNING").IsCyclic();

            modelBuilder.HasSequence("SQ_THE_STANDARD").IsCyclic();

            modelBuilder.HasSequence("SQ_TIME_BOARD_SET_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_TIME_BOARD_SETTING").IsCyclic();

            modelBuilder.HasSequence("SQ_TIME_SHEET_ABSENCE").IsCyclic();

            modelBuilder.HasSequence("SQ_TIME_SHEET_ASSIGN").IsCyclic();

            modelBuilder.HasSequence("SQ_TIME_SHEET_SALARY").IsCyclic();

            modelBuilder.HasSequence("SQ_TIME_SHEET_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_TIMESHEET_EVENT").IsCyclic();

            modelBuilder.HasSequence("SQ_TMP_IRIS_IP_ENT").IsCyclic();

            modelBuilder.HasSequence("SQ_TRADE_CERTIF").IsCyclic();

            modelBuilder.HasSequence("SQ_TRADE_CERTIF_I").IsCyclic();

            modelBuilder.HasSequence("SQ_TRADE_CERTIF_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_TRAN_CHAIN").IsCyclic();

            modelBuilder.HasSequence("SQ_TRAN_COMP_TAG").IsCyclic();

            modelBuilder.HasSequence("SQ_TRAN_TUNING_ELEM").IsCyclic();

            modelBuilder.HasSequence("SQ_TRANS_PERM_I_CARD").IsCyclic();

            modelBuilder.HasSequence("SQ_TRANSACTION_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_TRANSACTION_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_TRANSPORT").IsCyclic();

            modelBuilder.HasSequence("SQ_TRANSPORT_POINT").IsCyclic();

            modelBuilder.HasSequence("SQ_TRANSPORT_RESOURCE").IsCyclic();

            modelBuilder.HasSequence("SQ_TRANSPORT_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_TREATY").IsCyclic();

            modelBuilder.HasSequence("SQ_TREATY_TERMINAL_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_TREE_CH_FUN").IsCyclic();

            modelBuilder.HasSequence("SQ_TRIP_TRAN_TARIF").IsCyclic();

            modelBuilder.HasSequence("SQ_TRK").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_ACTIVITY").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_AGENT_BUY").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_APPEARANCE").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_ARTICLE").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_ARTICLE_IMAGE").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_BILL_POSITION").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_BILL_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_BUY_SRC").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_CALC_SERVICE").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_CONCESSION").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_CURATOR").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_DEFAULT").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_DEFAULT_FACTOR").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_DEFAULT_PARAM").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_DEPOSIT").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_EVENT").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_EVENT_TUNING").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_EVENT_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_FACTOR").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_FACTOR_DISCRIM").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_FACTOR_ENT").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_FACTOR_VALUE").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_HIER").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_ITEM_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_ITEM_VALUE").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_ITEM_VALUE_MTX").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_OUR_ACC").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_PARAM_DEFAULT").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_PARAM_DISCRIM").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_PARAM_GIVEN").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_PARAM_ITEM").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_PARAMETER").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_PARTY").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_PARTY_KIND").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_PERSON").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_PERSON_BASE").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_PERSON_TITLE").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_PRINCIPAL").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_PRINCIPAL_ACC").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_PROCSTAN").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_RESERVED_NUMBER").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_RESOURCE_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_RW_LINE").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_RW_LINE_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_SECTION").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_SET").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_SET_OF_NUMBERS").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_SET_OFF").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_TERMINAL").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_TERMINAL_RW_LINE_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_TRADE_CERTIF").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_TREATY_GIVEN").IsCyclic();

            modelBuilder.HasSequence("SQ_TRT_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_TRUCK_CHASSIS").IsCyclic();

            modelBuilder.HasSequence("SQ_TRUCK_CLASS").IsCyclic();

            modelBuilder.HasSequence("SQ_TRUCK_CLASS_COEFF").IsCyclic();

            modelBuilder.HasSequence("SQ_TRUCK_GOODS").IsCyclic();

            modelBuilder.HasSequence("SQ_TRUCK_LEVEL").IsCyclic();

            modelBuilder.HasSequence("SQ_TRUCK_OWNER").IsCyclic();

            modelBuilder.HasSequence("SQ_TRUCK_PROPERTY").IsCyclic();

            modelBuilder.HasSequence("SQ_TRUCK_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_TRUCK_TYPE_CHASSIS").IsCyclic();

            modelBuilder.HasSequence("SQ_TRUNK_LOSS").IsCyclic();

            modelBuilder.HasSequence("SQ_TUNING_ST_AZS").IsCyclic();

            modelBuilder.HasSequence("SQ_TUNING_ST_AZS_ITEM").IsCyclic();

            modelBuilder.HasSequence("SQ_TYPE_OWNER").IsCyclic();

            modelBuilder.HasSequence("SQ_TYPE_OWNER_DISCRIM").IsCyclic();

            modelBuilder.HasSequence("SQ_UNIT_JOB_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_UNIT_OF_MEASURE").IsCyclic();

            modelBuilder.HasSequence("SQ_UPTIME_ASSIGN").IsCyclic();

            modelBuilder.HasSequence("SQ_UPTIME_ASSIGN_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_UPTIME_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_UPTIME_TYPE_ABSENCE").IsCyclic();

            modelBuilder.HasSequence("SQ_USER_ASSIGNMENT").IsCyclic();

            modelBuilder.HasSequence("SQ_USER_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_USER_IN_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_USER_INSTRUCTION").IsCyclic();

            modelBuilder.HasSequence("SQ_USER_RESPONS").IsCyclic();

            modelBuilder.HasSequence("SQ_USER_SESSION").IsCyclic();

            modelBuilder.HasSequence("SQ_USER_SESSION_FORM").IsCyclic();

            modelBuilder.HasSequence("SQ_USER_SESSION_HIER").IsCyclic();

            modelBuilder.HasSequence("SQ_USER_SESSION_HIST").IsCyclic();

            modelBuilder.HasSequence("SQ_USER_SESSION_ORG").IsCyclic();

            modelBuilder.HasSequence("SQ_VALUE_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_VISA_DEP").IsCyclic();

            modelBuilder.HasSequence("SQ_VISA_POS").IsCyclic();

            modelBuilder.HasSequence("SQ_VZNGR_DIST").IsCyclic();

            modelBuilder.HasSequence("SQ_VZNGR_DIST_OWNER").IsCyclic();

            modelBuilder.HasSequence("SQ_VZNGR_DIST_RATE").IsCyclic();

            modelBuilder.HasSequence("SQ_VZNGR_DIST_SET").IsCyclic();

            modelBuilder.HasSequence("SQ_WATER_POSITION").IsCyclic();

            modelBuilder.HasSequence("SQ_WATERPORT").IsCyclic();

            modelBuilder.HasSequence("SQ_WATERWAY").IsCyclic();

            modelBuilder.HasSequence("SQ_WATERWAY_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_WAYBILL_CAR_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_WAYBILL_OPERATION").IsCyclic();

            modelBuilder.HasSequence("SQ_WAYBILL_SEASON").IsCyclic();

            modelBuilder.HasSequence("SQ_WAYBILL_TARIF").IsCyclic();

            modelBuilder.HasSequence("SQ_WBILL_NOT_PRESENT").IsCyclic();

            modelBuilder.HasSequence("SQ_WBILL_RW_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_WEIGHT_DEFINITION").IsCyclic();

            modelBuilder.HasSequence("SQ_WEIGHT_PROTOCOL").IsCyclic();

            modelBuilder.HasSequence("SQ_WEIGHT_PROTOCOL_I").IsCyclic();

            modelBuilder.HasSequence("SQ_WORK_WEEK_DAY").IsCyclic();

            modelBuilder.HasSequence("SQ_WORK_WEEK_DAY_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_WORK_WEEK_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_WORKBOOK").IsCyclic();

            modelBuilder.HasSequence("SQ_WORKS").IsCyclic();

            modelBuilder.HasSequence("SQ_WRITE_DOWN_INVOICE").IsCyclic();

            modelBuilder.HasSequence("SQ_WW_DISTANCE").IsCyclic();

            modelBuilder.HasSequence("SQ_XML_ATTRIBUTE").IsCyclic();

            modelBuilder.HasSequence("SQ_XML_DOC_TYPE").IsCyclic();

            modelBuilder.HasSequence("SQ_XML_DOC_TYPE_UNIT").IsCyclic();

            modelBuilder.HasSequence("SQ_XML_ELEMENT").IsCyclic();

            modelBuilder.HasSequence("SQ_XML_ELEMENT_DESC").IsCyclic();

            modelBuilder.HasSequence("SQ_XML_ELEMENT_HIER").IsCyclic();

            modelBuilder.HasSequence("SQ_ZABBIX_HISTORY").IsCyclic();

            modelBuilder.HasSequence("SQ_ZABBIX_PARAM").IsCyclic();

            modelBuilder.HasSequence("SQ_ZR_TBL_ORDER").IsCyclic();

            modelBuilder.HasSequence("SQ_ZREPL_ANSW").IsCyclic();

            modelBuilder.HasSequence("SQ_ZREPL_CAG").IsCyclic();

            modelBuilder.HasSequence("SQ_ZREPL_EVENT").IsCyclic();

            modelBuilder.HasSequence("SQ_ZREPL_META").IsCyclic();

            modelBuilder.HasSequence("SQ_ZREPL_MSG").IsCyclic();

            modelBuilder.HasSequence("SQ_ZREPL_MSG_I").IsCyclic();

            modelBuilder.HasSequence("SQ_ZREPL_SERVER").IsCyclic();

            modelBuilder.HasSequence("SQ_ZREPL_SERVER_ENT").IsCyclic();

            modelBuilder.HasSequence("SQ_ZREPL_SERVER_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_ZREPL_TBL").IsCyclic();

            modelBuilder.HasSequence("SQ_ZREPL_TBL_GROUP").IsCyclic();

            modelBuilder.HasSequence("SQ_ZSTO_GRUPPA").IsCyclic();

            modelBuilder.HasSequence("SQ_ZSTO_PERIODICHNOST").IsCyclic();

            modelBuilder.HasSequence("SQ_ZSTO_TIP_OBORUD").IsCyclic();

            modelBuilder.HasSequence("SQ_ZSTO_TIP_REMONTA").IsCyclic();

            modelBuilder.HasSequence("SQ_ZSTO_USLOVIE").IsCyclic();

            modelBuilder.HasSequence("SQA_AUDIT_ERROR").IsCyclic();

            modelBuilder.HasSequence("SQA_IRIS_EMP_PERS_DEVICE").IsCyclic();

            modelBuilder.HasSequence("SQA_IRIS_INET_TARIF").IsCyclic();

            modelBuilder.HasSequence("SQA_IRIS_PERS_DEVICE").IsCyclic();

            modelBuilder.HasSequence("SQA_IRIS_POWER_TARIF").IsCyclic();

            modelBuilder.HasSequence("SQLN_PROF_NUMBER").IsCyclic();

            modelBuilder.HasSequence("SQN_2002").IsCyclic();

            modelBuilder.HasSequence("SQN_ACCEPT_REPORT").IsCyclic();

            modelBuilder.HasSequence("SQN_BANK_EXTRACTION").IsCyclic();

            modelBuilder.HasSequence("SQN_CA_CARD_INVENT").IsCyclic();

            modelBuilder.HasSequence("SQN_COVER_SHEET").IsCyclic();

            modelBuilder.HasSequence("SQN_FLOWMETER").IsCyclic();

            modelBuilder.HasSequence("SQN_IN_INVOICE").IsCyclic();

            modelBuilder.HasSequence("SQN_INVENTORY").IsCyclic();

            modelBuilder.HasSequence("SQN_OS").IsCyclic();

            modelBuilder.HasSequence("SQN_OUT_ORDER_MO_OS").IsCyclic();

            modelBuilder.HasSequence("SQN_OUT_ORDER_OS_NUM").IsCyclic();

            modelBuilder.HasSequence("SQN_OUT_ORDER_OS_S").IsCyclic();

            modelBuilder.HasSequence("SQN_OUT_ORDER_RW_OS").IsCyclic();

            modelBuilder.HasSequence("SQN_OUT_ORDER_WA_OS").IsCyclic();

            modelBuilder.HasSequence("SQN_OUT_WBILL_MO_OS_PNB").IsCyclic();

            modelBuilder.HasSequence("SQN_OUT_WBILL_MO_OS_PNB1").IsCyclic();

            modelBuilder.HasSequence("SQN_PAY_DICT_REG_NUMBER");

            modelBuilder.HasSequence("SQN_PRICE_LIST").IsCyclic();

            modelBuilder.HasSequence("SQN_R3_RU_INVENT").IsCyclic();

            modelBuilder.HasSequence("SQN_R3_RUI_INVENT").IsCyclic();

            modelBuilder.HasSequence("SQN_R3_RUM_INVENT").IsCyclic();

            modelBuilder.HasSequence("SQN_RECEIPT_DOC_PNB").IsCyclic();

            modelBuilder.HasSequence("SQN_REQUISITION").IsCyclic();

            modelBuilder.HasSequence("SQN_SEC_PAY_CUST").IsCyclic();

            modelBuilder.HasSequence("SQN_SEC_PAY_SUPP").IsCyclic();

            modelBuilder.HasSequence("SQN_SECURITIES").IsCyclic();

            modelBuilder.HasSequence("SQN_SEQURITIES_DEED").IsCyclic();

            modelBuilder.HasSequence("SQN_SHIFT_REP_NB_PNB").IsCyclic();

            modelBuilder.HasSequence("SQN_SHIFT_REPORT").IsCyclic();

            modelBuilder.HasSequence("SQN_STROKE_CODE").IsCyclic();

            modelBuilder.HasSequence("SQN_TREATY").IsCyclic();

            modelBuilder.HasSequence("SQN_TRUST").IsCyclic();

            modelBuilder.HasSequence("SQN_TRUST_BUY").IsCyclic();

            modelBuilder.HasSequence("YMV_DEPEND_SQ").IsCyclic();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
