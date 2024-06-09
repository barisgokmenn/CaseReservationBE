using CaseEptera.Reservation.Domain.Entities;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseEptera.Reservation.Infrastructure.Persistence
{
    public class ReservationDbContext : DbContext
    {
        public ReservationDbContext(DbContextOptions<ReservationDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Roomtypes
            Guid singleRoomTypeId = Guid.NewGuid();
            Guid familyRoomTypeId = Guid.NewGuid();
            Guid deluxeRoomTypeId = Guid.NewGuid();

            modelBuilder.Entity<Roomtype>().HasData(
                new Roomtype
                {
                    RecId = singleRoomTypeId,
                    RoomTypeName = "Single",
                    Adult = 2,
                    Child = 0,
                    RoomCount = 10,
                    Deleted = false
                },
                new Roomtype
                {
                    RecId = familyRoomTypeId,
                    RoomTypeName = "Family",
                    Adult = 2,
                    Child = 2,
                    RoomCount = 15,
                    Deleted = false
                },
                new Roomtype
                {
                    RecId = deluxeRoomTypeId,
                    RoomTypeName = "Deluxe",
                    Adult = 2,
                    Child = 3,
                    RoomCount = 5,
                    Deleted = false
                }
            );

            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now.AddDays(30);

            // Seed data for Prices
            modelBuilder.Entity<Prices>().HasData(
                new Prices
                {
                    RecId = Guid.NewGuid(),
                    StartDate = startDate,
                    EndDate = endDate,
                    Adult = 2,
                    Child = 0,
                    Price = 50.00,
                    Deleted = false
                },
                new Prices
                {
                    RecId = Guid.NewGuid(),
                    StartDate = startDate,
                    EndDate = endDate,
                    Adult = 2,
                    Child = 2,
                    Price = 150.00,
                    Deleted = false
                },
                new Prices
                {
                    RecId = Guid.NewGuid(),
                    StartDate = startDate,
                    EndDate = endDate,
                    Adult = 2,
                    Child = 3,
                    Price = 300.00,
                    Deleted = false
                }
            );

            // Seed data for Reservationinfo
            modelBuilder.Entity<Reservationinfo>().HasData(
                new Reservationinfo
                {
                    RecId = Guid.NewGuid(),
                    GuestName = "Alice Johnson",
                    CheckinDate = DateTime.Now.AddDays(2),
                    CheckoutDate = DateTime.Now.AddDays(5),
                    Adult = 2,
                    Child = 0,
                    Child1 = 0,
                    Child2 = 0,
                    Child3 = 0,
                    RoomTypeId = singleRoomTypeId,
                    Price = 150.00,
                    Deleted = false
                },
                new Reservationinfo
                {
                    RecId = Guid.NewGuid(),
                    GuestName = "Bob Williams",
                    CheckinDate = DateTime.Now.AddDays(3),
                    CheckoutDate = DateTime.Now.AddDays(7),
                    Adult = 2,
                    Child = 2,
                    Child1 = 6,
                    Child2 = 4,
                    Child3 = 0,
                    RoomTypeId = familyRoomTypeId,
                    Price = 400.00,
                    Deleted = false
                },
                new Reservationinfo
                {
                    RecId = Guid.NewGuid(),
                    GuestName = "Carol Smith",
                    CheckinDate = DateTime.Now.AddDays(4),
                    CheckoutDate = DateTime.Now.AddDays(8),
                    Adult = 2,
                    Child = 3,
                    Child1 = 7,
                    Child2 = 5,
                    Child3 = 3,
                    RoomTypeId = deluxeRoomTypeId,
                    Price = 600.00,
                    Deleted = false
                }
            );

            // Seed data for Roomquota
            modelBuilder.Entity<Roomquota>().HasData(
                new Roomquota
                {
                    RecId = Guid.NewGuid(),
                    StartDate = startDate,
                    EndDate = endDate,
                    RoomTypeId = singleRoomTypeId,
                    AvailableRoomCount = 8,
                    Deleted = false
                },
                new Roomquota
                {
                    RecId = Guid.NewGuid(),
                    StartDate = startDate,
                    EndDate = endDate,
                    RoomTypeId = familyRoomTypeId,
                    AvailableRoomCount = 12,
                    Deleted = false
                },
                new Roomquota
                {
                    RecId = Guid.NewGuid(),
                    StartDate = startDate,
                    EndDate = endDate,
                    RoomTypeId = deluxeRoomTypeId,
                    AvailableRoomCount = 4,
                    Deleted = false
                }
            );
        }

        public int Execute(string query, object parameters)
        {
            return Database.GetDbConnection().Execute(query, parameters);
        }
        public List<T> SQLQuery<T>(string query, object parameters)
        {
            return Database.GetDbConnection().Query<T>(query, param: parameters).ToList();
        }
        public List<T> SQLQuery<T>(string query)
        {
            return Database.GetDbConnection().Query<T>(query).ToList();
        }

        #region DBSETS...

        public virtual DbSet<Prices> Prices { get; set; }
        public virtual DbSet<Roomtype> Roomtype { get; set; }
        public virtual DbSet<Roomquota> Roomquota { get; set; }
        public virtual DbSet<Reservationinfo> Reservationinfo { get; set; }

        #endregion
    }
}
