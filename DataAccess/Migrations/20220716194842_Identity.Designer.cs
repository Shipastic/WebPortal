﻿// <auto-generated />
using System;
using Infrastructures.Implementation.DataAccess.Oracle.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccess.Oracle.Migrations
{
    [DbContext(typeof(ModelContext))]
    [Migration("20220716194842_Identity")]
    partial class Identity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("NVARCHAR2(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("NUMBER(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("NUMBER(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("NVARCHAR2(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("NVARCHAR2(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("NVARCHAR2(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("\"NormalizedUserName\" IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Contractor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Bic")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<long>("BoardId")
                        .HasColumnType("NUMBER(19)");

                    b.Property<long>("CityId")
                        .HasColumnType("NUMBER(19)");

                    b.Property<DateTime?>("CloseDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<long>("ContractorTypeId")
                        .HasColumnType("NUMBER(19)");

                    b.Property<long>("EntId")
                        .HasColumnType("NUMBER(19)");

                    b.Property<long>("EstablishmentId")
                        .HasColumnType("NUMBER(19)");

                    b.Property<string>("Inn")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("NextCloseDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<DateTime>("NextRegDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Note")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("RegDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("Contractors");
                });

            modelBuilder.Entity("Entities.Models.IrisSdCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("NameIs")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("NameIs2")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Note")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("OtrsValue")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Priority")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<long>("SdServId")
                        .HasColumnType("NUMBER(19)");

                    b.HasKey("Id");

                    b.HasIndex("SdServId");

                    b.ToTable("IrisSdCategories");
                });

            modelBuilder.Entity("Entities.Models.IrisSdCompany", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long?>("CntId")
                        .HasColumnType("NUMBER(19)");

                    b.Property<string>("NameIs")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("NameIs2")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Note")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("OtrsValue")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("IrisSdCompanies");
                });

            modelBuilder.Entity("Entities.Models.IrisSdGrpLink", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("GrpObjId")
                        .HasColumnType("NUMBER(19)");

                    b.Property<string>("Note")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("OtrsValue")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<long>("SdSlaId")
                        .HasColumnType("NUMBER(19)");

                    b.HasKey("Id");

                    b.HasIndex("GrpObjId");

                    b.HasIndex("SdSlaId");

                    b.ToTable("IrisSdGrpLinks");
                });

            modelBuilder.Entity("Entities.Models.IrisSdGrpObj", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Note")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("IrisSdGrpObjs");
                });

            modelBuilder.Entity("Entities.Models.IrisSdService", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("NameIs")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("NameIs2")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Note")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("OtrsValue")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<long>("SdCompId")
                        .HasColumnType("NUMBER(19)");

                    b.HasKey("Id");

                    b.HasIndex("SdCompId");

                    b.ToTable("IrisSdServices");
                });

            modelBuilder.Entity("Entities.Models.IrisSdSla", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("NameIs")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("NameIs2")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Note")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("OtrsValue")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<long>("SdCatId")
                        .HasColumnType("NUMBER(19)");

                    b.HasKey("Id");

                    b.HasIndex("SdCatId");

                    b.ToTable("IrisSdSlas");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("NVARCHAR2(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("NVARCHAR2(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("\"NormalizedName\" IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("Value")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Entities.Models.IrisSdCategory", b =>
                {
                    b.HasOne("Entities.Models.IrisSdService", "SdServ")
                        .WithMany("IrisSdCategories")
                        .HasForeignKey("SdServId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SdServ");
                });

            modelBuilder.Entity("Entities.Models.IrisSdGrpLink", b =>
                {
                    b.HasOne("Entities.Models.IrisSdGrpObj", "GrpObj")
                        .WithMany("IrisSdGrpLinks")
                        .HasForeignKey("GrpObjId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.IrisSdSla", "SdSla")
                        .WithMany("IrisSdGrpLinks")
                        .HasForeignKey("SdSlaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrpObj");

                    b.Navigation("SdSla");
                });

            modelBuilder.Entity("Entities.Models.IrisSdService", b =>
                {
                    b.HasOne("Entities.Models.IrisSdCompany", "SdComp")
                        .WithMany("IrisSdServices")
                        .HasForeignKey("SdCompId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SdComp");
                });

            modelBuilder.Entity("Entities.Models.IrisSdSla", b =>
                {
                    b.HasOne("Entities.Models.IrisSdCategory", "SdCat")
                        .WithMany("IrisSdSlas")
                        .HasForeignKey("SdCatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SdCat");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Entities.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Entities.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Entities.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.IrisSdCategory", b =>
                {
                    b.Navigation("IrisSdSlas");
                });

            modelBuilder.Entity("Entities.Models.IrisSdCompany", b =>
                {
                    b.Navigation("IrisSdServices");
                });

            modelBuilder.Entity("Entities.Models.IrisSdGrpObj", b =>
                {
                    b.Navigation("IrisSdGrpLinks");
                });

            modelBuilder.Entity("Entities.Models.IrisSdService", b =>
                {
                    b.Navigation("IrisSdCategories");
                });

            modelBuilder.Entity("Entities.Models.IrisSdSla", b =>
                {
                    b.Navigation("IrisSdGrpLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
