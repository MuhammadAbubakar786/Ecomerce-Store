using Microsoft.EntityFrameworkCore.Migrations;

namespace TradePoster.Data.Migrations
{
    public partial class Packages_table_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageExpiryDays = table.Column<int>(type: "int", nullable: false),
                    RegularListing = table.Column<int>(type: "int", nullable: false),
                    FeatureListing = table.Column<int>(type: "int", nullable: false),
                    NoOfImages = table.Column<int>(type: "int", nullable: false),
                    BusinessHours = table.Column<bool>(type: "bit", nullable: false),
                    AllowTags = table.Column<bool>(type: "bit", nullable: false),
                    SocialLinks = table.Column<bool>(type: "bit", nullable: false),
                    WebsiteLink = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Packages");
        }
    }
}
