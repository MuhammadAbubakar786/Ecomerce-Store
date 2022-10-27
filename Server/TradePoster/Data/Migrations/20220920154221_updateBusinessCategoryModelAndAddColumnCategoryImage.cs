using Microsoft.EntityFrameworkCore.Migrations;

namespace TradePoster.Data.Migrations
{
    public partial class updateBusinessCategoryModelAndAddColumnCategoryImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryImage",
                table: "BusinessCategories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryImage",
                table: "BusinessCategories");
        }
    }
}
