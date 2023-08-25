using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("c143b841-edfa-4e90-bce0-d248791f6aba"), new Guid("00000000-0000-0000-0000-000000000000"), "kamolsobir@gmail.com", "Kamol", "Sobirov", "99899987834" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c143b841-edfa-4e90-bce0-d248791f6aba"));
        }
    }
}
