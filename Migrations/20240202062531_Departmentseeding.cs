using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelDeskAPI.Migrations
{
    /// <inheritdoc />
    public partial class Departmentseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DeptId", "CreateBy", "CreatedOn", "DepartmentName", "IsActive", "UpdateBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2024, 2, 2, 11, 55, 30, 971, DateTimeKind.Local).AddTicks(7942), "HR", false, null, null },
                    { 2, 0, new DateTime(2024, 2, 2, 11, 55, 30, 971, DateTimeKind.Local).AddTicks(7944), "Admin", false, null, null },
                    { 3, 0, new DateTime(2024, 2, 2, 11, 55, 30, 971, DateTimeKind.Local).AddTicks(7944), "IT", false, null, null },
                    { 4, 0, new DateTime(2024, 2, 2, 11, 55, 30, 971, DateTimeKind.Local).AddTicks(7945), "Sales", false, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 2, 11, 55, 30, 971, DateTimeKind.Local).AddTicks(7820));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 2, 11, 55, 30, 971, DateTimeKind.Local).AddTicks(7831));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 2, 11, 55, 30, 971, DateTimeKind.Local).AddTicks(7832));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 2, 11, 55, 30, 971, DateTimeKind.Local).AddTicks(7833));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "DeptId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "DeptId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "DeptId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "DeptId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 30, 0, 6, 18, 938, DateTimeKind.Local).AddTicks(8186));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 30, 0, 6, 18, 938, DateTimeKind.Local).AddTicks(8199));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 30, 0, 6, 18, 938, DateTimeKind.Local).AddTicks(8200));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 30, 0, 6, 18, 938, DateTimeKind.Local).AddTicks(8201));
        }
    }
}
