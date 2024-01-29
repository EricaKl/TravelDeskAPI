using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelDeskAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_User_ManagerId",
                table: "User",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_ManagerId",
                table: "User",
                column: "ManagerId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_User_ManagerId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ManagerId",
                table: "User");
        }
    }
}
