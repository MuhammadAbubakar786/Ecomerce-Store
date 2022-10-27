using Microsoft.EntityFrameworkCore.Migrations;

namespace TradePoster.Data.Migrations
{
    public partial class UserProfileAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MondayFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MondayTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TuesdayFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TuesdayTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WednesdayFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WednesdayTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThursdayFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThursdayTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FridayFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FridayTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaturdayFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaturdayTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SundayFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SundayTo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessHours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessIndustryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedInUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YouttubeUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GooglePlusUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    BusinessHoursId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfile_BusinessHours_BusinessHoursId",
                        column: x => x.BusinessHoursId,
                        principalTable: "BusinessHours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfile_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_BusinessHoursId",
                table: "UserProfile",
                column: "BusinessHoursId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_CompanyId",
                table: "UserProfile",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropTable(
                name: "BusinessHours");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
