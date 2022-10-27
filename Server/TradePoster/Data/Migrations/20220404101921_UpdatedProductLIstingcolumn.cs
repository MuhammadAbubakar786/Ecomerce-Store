using Microsoft.EntityFrameworkCore.Migrations;

namespace TradePoster.Data.Migrations
{
    public partial class UpdatedProductLIstingcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userHash",
                table: "UserSubscriptionMatrix",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userHash",
                table: "UserSubscriptionMatrix");
        }
    }
}
