using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OfferManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitiaCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegisteredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 15, 12, 0, 0, 0, DateTimeKind.Utc), "Major Auto" },
                    { 2, new DateTime(2025, 7, 15, 12, 0, 0, 0, DateTimeKind.Utc), "Avilon" },
                    { 3, new DateTime(2025, 7, 15, 12, 0, 0, 0, DateTimeKind.Utc), "Rolf" },
                    { 4, new DateTime(2025, 7, 15, 12, 0, 0, 0, DateTimeKind.Utc), "AutoSpecCenter" },
                    { 5, new DateTime(2025, 7, 15, 12, 0, 0, 0, DateTimeKind.Utc), "Inchcape" }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Brand", "Model", "RegisteredAt", "SupplierId" },
                values: new object[,]
                {
                    { 1, "Toyota", "Camry", new DateTime(2025, 7, 16, 10, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 2, "Toyota", "RAV4", new DateTime(2025, 7, 16, 10, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 3, "BMW", "X5", new DateTime(2025, 7, 16, 10, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 4, "BMW", "3 Series", new DateTime(2025, 7, 16, 10, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 5, "Mercedes-Benz", "E-Class", new DateTime(2025, 7, 16, 10, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 6, "Audi", "A6", new DateTime(2025, 7, 16, 10, 0, 0, 0, DateTimeKind.Utc), 3 },
                    { 7, "Audi", "Q7", new DateTime(2025, 7, 16, 10, 0, 0, 0, DateTimeKind.Utc), 3 },
                    { 8, "Hyundai", "Solaris", new DateTime(2025, 7, 16, 10, 0, 0, 0, DateTimeKind.Utc), 3 },
                    { 9, "Kia", "Rio", new DateTime(2025, 7, 16, 10, 0, 0, 0, DateTimeKind.Utc), 3 },
                    { 10, "Volkswagen", "Tiguan", new DateTime(2025, 7, 16, 10, 0, 0, 0, DateTimeKind.Utc), 4 },
                    { 11, "Volkswagen", "Polo", new DateTime(2025, 7, 16, 10, 0, 0, 0, DateTimeKind.Utc), 4 },
                    { 12, "Skoda", "Octavia", new DateTime(2025, 7, 16, 10, 0, 0, 0, DateTimeKind.Utc), 4 },
                    { 13, "Lada", "Vesta", new DateTime(2025, 7, 16, 10, 0, 0, 0, DateTimeKind.Utc), 5 },
                    { 14, "Lada", "Granta", new DateTime(2025, 7, 16, 10, 0, 0, 0, DateTimeKind.Utc), 5 },
                    { 15, "Ford", "Focus", new DateTime(2025, 7, 16, 10, 0, 0, 0, DateTimeKind.Utc), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_SupplierId",
                table: "Offers",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
