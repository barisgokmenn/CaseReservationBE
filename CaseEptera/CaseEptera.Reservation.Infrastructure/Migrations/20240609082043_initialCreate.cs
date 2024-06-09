using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CaseEptera.Reservation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    RecId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Deleted = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adult = table.Column<int>(type: "int", nullable: false),
                    Child = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.RecId);
                });

            migrationBuilder.CreateTable(
                name: "Reservationinfo",
                columns: table => new
                {
                    RecId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Deleted = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    GuestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckoutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adult = table.Column<int>(type: "int", nullable: false),
                    Child = table.Column<int>(type: "int", nullable: false),
                    Child1 = table.Column<int>(type: "int", nullable: false),
                    Child2 = table.Column<int>(type: "int", nullable: false),
                    Child3 = table.Column<int>(type: "int", nullable: false),
                    RoomTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservationinfo", x => x.RecId);
                });

            migrationBuilder.CreateTable(
                name: "Roomquota",
                columns: table => new
                {
                    RecId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Deleted = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoomTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvailableRoomCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roomquota", x => x.RecId);
                });

            migrationBuilder.CreateTable(
                name: "Roomtype",
                columns: table => new
                {
                    RecId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Deleted = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    RoomTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adult = table.Column<int>(type: "int", nullable: false),
                    Child = table.Column<int>(type: "int", nullable: false),
                    RoomCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roomtype", x => x.RecId);
                });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "RecId", "Adult", "Child", "Deleted", "EndDate", "Price", "StartDate" },
                values: new object[,]
                {
                    { new Guid("0f3d39ab-8007-4bb4-b77f-d85037aa827a"), 2, 3, "0", new DateTime(2024, 7, 9, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6535), 300.0, new DateTime(2024, 6, 9, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6528) },
                    { new Guid("d7bbbdcc-37d6-4453-874a-76e1ba6efe78"), 2, 0, "0", new DateTime(2024, 7, 9, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6535), 50.0, new DateTime(2024, 6, 9, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6528) },
                    { new Guid("fd7c45d1-f376-4fbc-afdc-96318d1149c8"), 2, 2, "0", new DateTime(2024, 7, 9, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6535), 150.0, new DateTime(2024, 6, 9, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6528) }
                });

            migrationBuilder.InsertData(
                table: "Reservationinfo",
                columns: new[] { "RecId", "Adult", "CheckinDate", "CheckoutDate", "Child", "Child1", "Child2", "Child3", "Deleted", "GuestName", "Price", "RoomTypeId" },
                values: new object[,]
                {
                    { new Guid("02ad3787-39c6-42c9-b78b-94f8f45ffbdb"), 2, new DateTime(2024, 6, 13, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6599), new DateTime(2024, 6, 17, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6599), 3, 7, 5, 3, "0", "Carol Smith", 600.0, new Guid("d6aa3959-98a2-4ff7-92f2-49a6ad3530db") },
                    { new Guid("4e99c233-a590-49db-98b3-17e843bc8dae"), 2, new DateTime(2024, 6, 11, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6589), new DateTime(2024, 6, 14, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6590), 0, 0, 0, 0, "0", "Alice Johnson", 150.0, new Guid("5d92b716-d0d0-472d-8213-6233c448eab2") },
                    { new Guid("6cec4dd1-582a-45f2-87e0-daa4c801575b"), 2, new DateTime(2024, 6, 12, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6596), new DateTime(2024, 6, 16, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6596), 2, 6, 4, 0, "0", "Bob Williams", 400.0, new Guid("eea220bb-890d-4cc3-922b-cc7532377225") }
                });

            migrationBuilder.InsertData(
                table: "Roomquota",
                columns: new[] { "RecId", "AvailableRoomCount", "Deleted", "EndDate", "RoomTypeId", "StartDate" },
                values: new object[,]
                {
                    { new Guid("67203248-105e-4678-93e2-2c25035edc88"), 12, "0", new DateTime(2024, 7, 9, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6535), new Guid("eea220bb-890d-4cc3-922b-cc7532377225"), new DateTime(2024, 6, 9, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6528) },
                    { new Guid("d641baed-b5d8-4149-b4e7-95ac58ca9151"), 4, "0", new DateTime(2024, 7, 9, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6535), new Guid("d6aa3959-98a2-4ff7-92f2-49a6ad3530db"), new DateTime(2024, 6, 9, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6528) },
                    { new Guid("dc5165b1-3ac3-4b39-86c6-e39d3b0840be"), 8, "0", new DateTime(2024, 7, 9, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6535), new Guid("5d92b716-d0d0-472d-8213-6233c448eab2"), new DateTime(2024, 6, 9, 11, 20, 43, 747, DateTimeKind.Local).AddTicks(6528) }
                });

            migrationBuilder.InsertData(
                table: "Roomtype",
                columns: new[] { "RecId", "Adult", "Child", "Deleted", "RoomCount", "RoomTypeName" },
                values: new object[,]
                {
                    { new Guid("5d92b716-d0d0-472d-8213-6233c448eab2"), 2, 0, "0", 10, "Single" },
                    { new Guid("d6aa3959-98a2-4ff7-92f2-49a6ad3530db"), 2, 3, "0", 5, "Deluxe" },
                    { new Guid("eea220bb-890d-4cc3-922b-cc7532377225"), 2, 2, "0", 15, "Family" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Reservationinfo");

            migrationBuilder.DropTable(
                name: "Roomquota");

            migrationBuilder.DropTable(
                name: "Roomtype");
        }
    }
}
