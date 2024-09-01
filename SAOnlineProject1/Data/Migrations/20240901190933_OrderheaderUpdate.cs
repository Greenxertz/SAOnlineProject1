using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAOnlineProject1.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrderheaderUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carrier",
                table: "orderHeaders");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "orderHeaders");

            migrationBuilder.DropColumn(
                name: "TrackingNumber",
                table: "orderHeaders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Carrier",
                table: "orderHeaders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "orderHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TrackingNumber",
                table: "orderHeaders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
