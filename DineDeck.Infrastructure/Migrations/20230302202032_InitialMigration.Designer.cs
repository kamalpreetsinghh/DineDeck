﻿// <auto-generated />
using System;
using DineDeck.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DineDeck.Infrastructure.Migrations
{
    [DbContext(typeof(DineDeckDbContext))]
    [Migration("20230302202032_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DineDeck.Domain.BillAggregate.Bill", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("BillId");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DinnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GuestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Bills", (string)null);
                });

            modelBuilder.Entity("DineDeck.Domain.DinnerAggregate.Dinner", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("DinnerId");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("HostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<int>("MaxGuests")
                        .HasColumnType("int");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Dinners", (string)null);
                });

            modelBuilder.Entity("DineDeck.Domain.GuestAggregate.Guest", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("GuestId");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProfileImage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Guests", (string)null);
                });

            modelBuilder.Entity("DineDeck.Domain.HostAggregate.Host", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("HostId");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProfileImage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.ToTable("Hosts", (string)null);
                });

            modelBuilder.Entity("DineDeck.Domain.MenuReviewAggregate.MenuReview", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("MenuReviewId");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DinnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GuestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("MenuReviews", (string)null);
                });

            modelBuilder.Entity("DineDeck.Domain.UserAggregate.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("DineDeck.Domain.BillAggregate.Bill", b =>
                {
                    b.OwnsOne("DineDeck.Domain.Common.ValueObjects.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("BillId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Amount")
                                .HasColumnType("float");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("BillId");

                            b1.ToTable("Bills");

                            b1.WithOwner()
                                .HasForeignKey("BillId");
                        });

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("DineDeck.Domain.DinnerAggregate.Dinner", b =>
                {
                    b.OwnsOne("DineDeck.Domain.Common.ValueObjects.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("DinnerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Amount")
                                .HasColumnType("float");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DinnerId");

                            b1.ToTable("Dinners");

                            b1.WithOwner()
                                .HasForeignKey("DinnerId");
                        });

                    b.OwnsMany("DineDeck.Domain.DinnerAggregate.Entities.Reservation", "Reservations", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("DinnerReservationId");

                            b1.Property<Guid>("DinnerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("ArrivalDateTime")
                                .HasColumnType("datetime2");

                            b1.Property<Guid>("BillId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("CreatedDateTime")
                                .HasColumnType("datetime2");

                            b1.Property<Guid>("GuestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("NumberOfGuests")
                                .HasColumnType("int");

                            b1.Property<int>("Status")
                                .HasColumnType("int");

                            b1.Property<DateTime>("UpdatedDateTime")
                                .HasColumnType("datetime2");

                            b1.HasKey("Id", "DinnerId");

                            b1.HasIndex("DinnerId");

                            b1.ToTable("DinnerReservations", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("DinnerId");
                        });

                    b.OwnsOne("DineDeck.Domain.DinnerAggregate.ValueObjects.Location", "Location", b1 =>
                        {
                            b1.Property<Guid>("DinnerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DinnerId");

                            b1.ToTable("Dinners");

                            b1.WithOwner()
                                .HasForeignKey("DinnerId");
                        });

                    b.Navigation("Location")
                        .IsRequired();

                    b.Navigation("Price")
                        .IsRequired();

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("DineDeck.Domain.GuestAggregate.Guest", b =>
                {
                    b.OwnsMany("DineDeck.Domain.BillAggregate.ValueObjects.BillId", "BillIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("GuestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("BillId");

                            b1.HasKey("Id");

                            b1.HasIndex("GuestId");

                            b1.ToTable("GuestBillIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("GuestId");
                        });

                    b.OwnsMany("DineDeck.Domain.GuestAggregate.Entities.GuestRating", "GuestRatings", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("GuestRatingsId");

                            b1.Property<Guid>("GuestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("CreatedDateTime")
                                .HasColumnType("datetime2");

                            b1.Property<Guid>("DinnerId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("DinnerId");

                            b1.Property<Guid>("HostId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("HostId");

                            b1.Property<int>("Rating")
                                .HasColumnType("int");

                            b1.Property<DateTime>("UpdatedDateTime")
                                .HasColumnType("datetime2");

                            b1.HasKey("Id", "GuestId");

                            b1.HasIndex("GuestId");

                            b1.ToTable("GuestRatings", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("GuestId");
                        });

                    b.OwnsMany("DineDeck.Domain.DinnerAggregate.ValueObjects.DinnerId", "PastDinnerIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("GuestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("DinnerId");

                            b1.HasKey("Id");

                            b1.HasIndex("GuestId");

                            b1.ToTable("GuestPastDinnerIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("GuestId");
                        });

                    b.OwnsMany("DineDeck.Domain.DinnerAggregate.ValueObjects.DinnerId", "PendingDinnerIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("GuestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("DinnerId");

                            b1.HasKey("Id");

                            b1.HasIndex("GuestId");

                            b1.ToTable("GuestPendingDinnerIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("GuestId");
                        });

                    b.OwnsMany("DineDeck.Domain.DinnerAggregate.ValueObjects.DinnerId", "UpcomingDinnerIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("GuestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("DinnerId");

                            b1.HasKey("Id");

                            b1.HasIndex("GuestId");

                            b1.ToTable("GuestUpcomingDinnerIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("GuestId");
                        });

                    b.OwnsMany("DineDeck.Domain.MenuReviewAggregate.ValueObjects.MenuReviewId", "MenuReviewIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("GuestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("MenuReviewId");

                            b1.HasKey("Id");

                            b1.HasIndex("GuestId");

                            b1.ToTable("GuestMenuReviewIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("GuestId");
                        });

                    b.Navigation("BillIds");

                    b.Navigation("GuestRatings");

                    b.Navigation("MenuReviewIds");

                    b.Navigation("PastDinnerIds");

                    b.Navigation("PendingDinnerIds");

                    b.Navigation("UpcomingDinnerIds");
                });

            modelBuilder.Entity("DineDeck.Domain.HostAggregate.Host", b =>
                {
                    b.OwnsOne("DineDeck.Domain.Common.ValueObjects.AverageRating", "AverageRating", b1 =>
                        {
                            b1.Property<Guid>("HostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("NumRatings")
                                .HasColumnType("int");

                            b1.Property<double>("Value")
                                .HasColumnType("float");

                            b1.HasKey("HostId");

                            b1.ToTable("Hosts");

                            b1.WithOwner()
                                .HasForeignKey("HostId");
                        });

                    b.OwnsMany("DineDeck.Domain.DinnerAggregate.ValueObjects.DinnerId", "DinnerIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("HostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("DinnerId");

                            b1.HasKey("Id");

                            b1.HasIndex("HostId");

                            b1.ToTable("HostDinnerIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("HostId");
                        });

                    b.OwnsMany("DineDeck.Domain.MenuAggregate.ValueObjects.MenuId", "MenuIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("HostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("MenuId");

                            b1.HasKey("Id");

                            b1.HasIndex("HostId");

                            b1.ToTable("HostMenuIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("HostId");
                        });

                    b.Navigation("AverageRating")
                        .IsRequired();

                    b.Navigation("DinnerIds");

                    b.Navigation("MenuIds");
                });
#pragma warning restore 612, 618
        }
    }
}
