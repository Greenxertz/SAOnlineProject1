using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAOnlineProject1.Data.Migrations
{
    /// <inheritdoc />
    public partial class CartUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCarts_AspNetUsers_userId",
                table: "UserCarts");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "UserCarts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCarts_userId",
                table: "UserCarts",
                newName: "IX_UserCarts_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCarts_AspNetUsers_UserId",
                table: "UserCarts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCarts_AspNetUsers_UserId",
                table: "UserCarts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserCarts",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCarts_UserId",
                table: "UserCarts",
                newName: "IX_UserCarts_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCarts_AspNetUsers_userId",
                table: "UserCarts",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
