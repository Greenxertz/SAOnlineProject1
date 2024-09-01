using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAOnlineProject1.Data.Migrations
{
    /// <inheritdoc />
    public partial class userOrderHeadersFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "State",
                table: "orderHeaders",
                newName: "Province");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Province",
                table: "orderHeaders",
                newName: "State");
        }
    }
}
