using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelDeskAPI.Migrations
{
    /// <inheritdoc />
    public partial class seeddatafeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "CreateBy", "CreatedOn", "IsActive", "RoleName", "UpdateBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2024, 1, 30, 0, 4, 56, 897, DateTimeKind.Local).AddTicks(595), false, "Admin", null, null },
                    { 2, 0, new DateTime(2024, 1, 30, 0, 4, 56, 897, DateTimeKind.Local).AddTicks(609), false, "HRAdmin", null, null },
                    { 3, 0, new DateTime(2024, 1, 30, 0, 4, 56, 897, DateTimeKind.Local).AddTicks(611), false, "Employee", null, null },
                    { 4, 0, new DateTime(2024, 1, 30, 0, 4, 56, 897, DateTimeKind.Local).AddTicks(612), false, "Manager", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 4);
        }
    }
}
