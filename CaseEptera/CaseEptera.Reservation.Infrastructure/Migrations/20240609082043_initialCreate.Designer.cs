﻿// <auto-generated />
using System;
using CaseEptera.Reservation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CaseEptera.Reservation.Infrastructure.Migrations
{
    [DbContext(typeof(ReservationDbContext))]
    [Migration("20240609082043_initialCreate")]
    partial class initialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CaseEptera.Reservation.Domain.Entities.Prices", b =>
                {
                    b.Property<Guid>("RecId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Adult")
                        .HasColumnType("int");

                    b.Property<int>("Child")
                        .HasColumnType("int");

                    b.Property<string>("Deleted")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RecId");

                    b.ToTable("Prices");

                    b.HasData(
                        new
                        {
                            RecId = new Guid("d7bbbdcc-37d6-4453-874a-76e1ba6efe78"),
                            Adult = 2,
                            Child = 0,
                            Deleted = "0",
                            EndDate = new DateTime(2024, 7, 9, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6535),
                            Price = 50.0,
                            StartDate = new DateTime(2024, 6, 9, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6528)
                        },
                        new
                        {
                            RecId = new Guid("fd7c45d1-f376-4fbc-afdc-96318d1149c8"),
                            Adult = 2,
                            Child = 2,
                            Deleted = "0",
                            EndDate = new DateTime(2024, 7, 9, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6535),
                            Price = 150.0,
                            StartDate = new DateTime(2024, 6, 9, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6528)
                        },
                        new
                        {
                            RecId = new Guid("0f3d39ab-8007-4bb4-b77f-d85037aa827a"),
                            Adult = 2,
                            Child = 3,
                            Deleted = "0",
                            EndDate = new DateTime(2024, 7, 9, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6535),
                            Price = 300.0,
                            StartDate = new DateTime(2024, 6, 9, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6528)
                        });
                });

            modelBuilder.Entity("CaseEptera.Reservation.Domain.Entities.Reservationinfo", b =>
                {
                    b.Property<Guid>("RecId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Adult")
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckinDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckoutDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Child")
                        .HasColumnType("int");

                    b.Property<int>("Child1")
                        .HasColumnType("int");

                    b.Property<int>("Child2")
                        .HasColumnType("int");

                    b.Property<int>("Child3")
                        .HasColumnType("int");

                    b.Property<string>("Deleted")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GuestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("RoomTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RecId");

                    b.ToTable("Reservationinfo");

                    b.HasData(
                        new
                        {
                            RecId = new Guid("4e99c233-a590-49db-98b3-17e843bc8dae"),
                            Adult = 2,
                            CheckinDate = new DateTime(2024, 6, 11, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6589),
                            CheckoutDate = new DateTime(2024, 6, 14, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6590),
                            Child = 0,
                            Child1 = 0,
                            Child2 = 0,
                            Child3 = 0,
                            Deleted = "0",
                            GuestName = "Alice Johnson",
                            Price = 150.0,
                            RoomTypeId = new Guid("5d92b716-d0d0-472d-8213-6233c448eab2")
                        },
                        new
                        {
                            RecId = new Guid("6cec4dd1-582a-45f2-87e0-daa4c801575b"),
                            Adult = 2,
                            CheckinDate = new DateTime(2024, 6, 12, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6596),
                            CheckoutDate = new DateTime(2024, 6, 16, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6596),
                            Child = 2,
                            Child1 = 6,
                            Child2 = 4,
                            Child3 = 0,
                            Deleted = "0",
                            GuestName = "Bob Williams",
                            Price = 400.0,
                            RoomTypeId = new Guid("eea220bb-890d-4cc3-922b-cc7532377225")
                        },
                        new
                        {
                            RecId = new Guid("02ad3787-39c6-42c9-b78b-94f8f45ffbdb"),
                            Adult = 2,
                            CheckinDate = new DateTime(2024, 6, 13, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6599),
                            CheckoutDate = new DateTime(2024, 6, 17, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6599),
                            Child = 3,
                            Child1 = 7,
                            Child2 = 5,
                            Child3 = 3,
                            Deleted = "0",
                            GuestName = "Carol Smith",
                            Price = 600.0,
                            RoomTypeId = new Guid("d6aa3959-98a2-4ff7-92f2-49a6ad3530db")
                        });
                });

            modelBuilder.Entity("CaseEptera.Reservation.Domain.Entities.Roomquota", b =>
                {
                    b.Property<Guid>("RecId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AvailableRoomCount")
                        .HasColumnType("int");

                    b.Property<string>("Deleted")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RoomTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RecId");

                    b.ToTable("Roomquota");

                    b.HasData(
                        new
                        {
                            RecId = new Guid("dc5165b1-3ac3-4b39-86c6-e39d3b0840be"),
                            AvailableRoomCount = 8,
                            Deleted = "0",
                            EndDate = new DateTime(2024, 7, 9, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6535),
                            RoomTypeId = new Guid("5d92b716-d0d0-472d-8213-6233c448eab2"),
                            StartDate = new DateTime(2024, 6, 9, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6528)
                        },
                        new
                        {
                            RecId = new Guid("67203248-105e-4678-93e2-2c25035edc88"),
                            AvailableRoomCount = 12,
                            Deleted = "0",
                            EndDate = new DateTime(2024, 7, 9, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6535),
                            RoomTypeId = new Guid("eea220bb-890d-4cc3-922b-cc7532377225"),
                            StartDate = new DateTime(2024, 6, 9, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6528)
                        },
                        new
                        {
                            RecId = new Guid("d641baed-b5d8-4149-b4e7-95ac58ca9151"),
                            AvailableRoomCount = 4,
                            Deleted = "0",
                            EndDate = new DateTime(2024, 7, 9, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6535),
                            RoomTypeId = new Guid("d6aa3959-98a2-4ff7-92f2-49a6ad3530db"),
                            StartDate = new DateTime(2024, 6, 9, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6528)
                        });
                });

            modelBuilder.Entity("CaseEptera.Reservation.Domain.Entities.Roomtype", b =>
                {
                    b.Property<Guid>("RecId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Adult")
                        .HasColumnType("int");

                    b.Property<int>("Child")
                        .HasColumnType("int");

                    b.Property<string>("Deleted")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RoomCount")
                        .HasColumnType("int");

                    b.Property<string>("RoomTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RecId");

                    b.ToTable("Roomtype");

                    b.HasData(
                        new
                        {
                            RecId = new Guid("5d92b716-d0d0-472d-8213-6233c448eab2"),
                            Adult = 2,
                            Child = 0,
                            Deleted = "0",
                            RoomCount = 10,
                            RoomTypeName = "Single"
                        },
                        new
                        {
                            RecId = new Guid("eea220bb-890d-4cc3-922b-cc7532377225"),
                            Adult = 2,
                            Child = 2,
                            Deleted = "0",
                            RoomCount = 15,
                            RoomTypeName = "Family"
                        },
                        new
                        {
                            RecId = new Guid("d6aa3959-98a2-4ff7-92f2-49a6ad3530db"),
                            Adult = 2,
                            Child = 3,
                            Deleted = "0",
                            RoomCount = 5,
                            RoomTypeName = "Deluxe"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
