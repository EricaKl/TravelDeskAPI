using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelDeskAPI.Migrations
{
    /// <inheritdoc />
    public partial class seeddatafeed1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 30, 0, 4, 56, 897, DateTimeKind.Local).AddTicks(595));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 30, 0, 4, 56, 897, DateTimeKind.Local).AddTicks(609));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 30, 0, 4, 56, 897, DateTimeKind.Local).AddTicks(611));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 30, 0, 4, 56, 897, DateTimeKind.Local).AddTicks(612));
        }
    }
}
