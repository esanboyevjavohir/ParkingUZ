﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ParkingUZ.DataAccess.Persistence;

#nullable disable

namespace ParkingUZ.DataAccess.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ParkingUZ.Core.Entities.Discount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<decimal>("DiscountPercent")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("ParkingZoneId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ParkingZoneId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("ParkingUZ.Core.Entities.GeoLocation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("XCoordinate")
                        .HasColumnType("numeric");

                    b.Property<decimal>("YCoordinate")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("GeoLocation");
                });

            modelBuilder.Entity("ParkingUZ.Core.Entities.ParkingSpot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("ParkingZoneId")
                        .HasColumnType("uuid");

                    b.Property<int>("SpotNumber")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ParkingZoneId");

                    b.ToTable("ParkingSpots");
                });

            modelBuilder.Entity("ParkingUZ.Core.Entities.ParkingSubscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("ParkingZoneId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SubscriptionPlanId")
                        .HasColumnType("uuid");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ParkingZoneId");

                    b.HasIndex("SubscriptionPlanId");

                    b.ToTable("ParkingSubscriptions");
                });

            modelBuilder.Entity("ParkingUZ.Core.Entities.ParkingZone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("GeoLocationId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("PricePerHour")
                        .HasColumnType("numeric");

                    b.Property<int>("TotalSpots")
                        .HasColumnType("integer");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("GeoLocationId")
                        .IsUnique();

                    b.ToTable("ParkingZones");
                });

            modelBuilder.Entity("ParkingUZ.Core.Entities.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PayStatus")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PaymentType")
                        .HasColumnType("integer");

                    b.Property<Guid>("ReservationId")
                        .HasColumnType("uuid");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("ParkingUZ.Core.Entities.QRCode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("GeneratedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("QRCodeData")
                        .HasColumnType("text");

                    b.Property<Guid>("ReservationId")
                        .HasColumnType("uuid");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.ToTable("QRCodes");
                });

            modelBuilder.Entity("ParkingUZ.Core.Entities.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("EntryTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("ExitTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("ParkingSpotId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ParkingSubscriptionId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<decimal?>("TotalPaid")
                        .HasColumnType("numeric");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ParkingSpotId");

                    b.HasIndex("ParkingSubscriptionId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("ParkingUZ.Core.Entities.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("ParkingZoneId")
                        .HasColumnType("uuid");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ParkingZoneId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("ParkingUZ.Core.Entities.SubscriptionPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("SubscriptionPlans");
                });

            modelBuilder.Entity("ParkingUZ.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Salt")
                        .HasColumnType("text");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ParkingUZ.DataAccess.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
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
                    b.HasOne("ParkingUZ.DataAccess.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ParkingUZ.DataAccess.Identity.ApplicationUser", null)
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

                    b.HasOne("ParkingUZ.DataAccess.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ParkingUZ.DataAccess.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ParkingUZ.Core.Entities.Discount", b =>
                {
                    b.HasOne("ParkingUZ.Core.Entities.ParkingZone", "ParkingZone")
                        .WithMany()
                        .HasForeignKey("ParkingZoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParkingZone");
                });

            modelBuilder.Entity("ParkingUZ.Core.Entities.ParkingSpot", b =>
                {
                    b.HasOne("ParkingUZ.Core.Entities.ParkingZone", "ParkingZone")
                        .WithMany()
                        .HasForeignKey("ParkingZoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParkingZone");
                });

            modelBuilder.Entity("ParkingUZ.Core.Entities.ParkingSubscription", b =>
                {
                    b.HasOne("ParkingUZ.Core.Entities.ParkingZone", "ParkingZone")
                        .WithMany()
                        .HasForeignKey("ParkingZoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkingUZ.Core.Entities.SubscriptionPlan", "SubscriptionPlan")
                        .WithMany()
                        .HasForeignKey("SubscriptionPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParkingZone");

                    b.Navigation("SubscriptionPlan");
                });

            modelBuilder.Entity("ParkingUZ.Core.Entities.ParkingZone", b =>
                {
                    b.HasOne("ParkingUZ.Core.Entities.GeoLocation", "GeoLocation")
                        .WithOne("ParkingZone")
                        .HasForeignKey("ParkingUZ.Core.Entities.ParkingZone", "GeoLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GeoLocation");
                });

            modelBuilder.Entity("ParkingUZ.Core.Entities.Payment", b =>
                {
                    b.HasOne("ParkingUZ.Core.Entities.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("ParkingUZ.Core.Entities.QRCode", b =>
                {
                    b.HasOne("ParkingUZ.Core.Entities.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("ParkingUZ.Core.Entities.Reservation", b =>
                {
                    b.HasOne("ParkingUZ.Core.Entities.ParkingSpot", "ParkingSpot")
                        .WithMany()
                        .HasForeignKey("ParkingSpotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkingUZ.Core.Entities.ParkingSubscription", "ParkingSubscription")
                        .WithMany()
                        .HasForeignKey("ParkingSubscriptionId");

                    b.HasOne("ParkingUZ.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParkingSpot");

                    b.Navigation("ParkingSubscription");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ParkingUZ.Core.Entities.Review", b =>
                {
                    b.HasOne("ParkingUZ.Core.Entities.ParkingZone", "ParkingZone")
                        .WithMany()
                        .HasForeignKey("ParkingZoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkingUZ.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParkingZone");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ParkingUZ.Core.Entities.GeoLocation", b =>
                {
                    b.Navigation("ParkingZone");
                });
#pragma warning restore 612, 618
        }
    }
}
