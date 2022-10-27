using Microsoft.EntityFrameworkCore.Migrations;

namespace TradePoster.Data.Migrations
{
    public partial class ListingStateUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "ProductListing",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "ProductListing");
        }
    }
}
