using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelDeskAPI.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Department_DepartmentId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_User_ManagerId",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Department_DepartmentId",
                table: "User",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_ManagerId",
                table: "User",
                column: "ManagerId",
                principalTable: "User",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Department_DepartmentId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_User_ManagerId",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Department_DepartmentId",
                table: "User",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_ManagerId",
                table: "User",
                column: "ManagerId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
