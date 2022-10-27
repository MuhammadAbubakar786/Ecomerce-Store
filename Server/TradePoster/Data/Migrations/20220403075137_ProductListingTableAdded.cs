using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradePoster.Data.Migrations
{
    public partial class ProductListingTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessHoursType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessHoursType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListingBusinessHours",
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
                    table.PrimaryKey("PK_ListingBusinessHours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListingCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListingType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductListing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListingTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pictures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessHoursTypeId = table.Column<int>(type: "int", nullable: true),
                    ListingTypeId = table.Column<int>(type: "int", nullable: true),
                    UserProfileId = table.Column<int>(type: "int", nullable: true),
                    ListingCategoryId = table.Column<int>(type: "int", nullable: true),
                    ListingBusinessHoursId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductListing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductListing_BusinessHoursType_BusinessHoursTypeId",
                        column: x => x.BusinessHoursTypeId,
                        principalTable: "BusinessHoursType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductListing_ListingBusinessHours_ListingBusinessHoursId",
                        column: x => x.ListingBusinessHoursId,
                        principalTable: "ListingBusinessHours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductListing_ListingCategory_ListingCategoryId",
                        column: x => x.ListingCategoryId,
                        principalTable: "ListingCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductListing_ListingType_ListingTypeId",
                        column: x => x.ListingTypeId,
                        principalTable: "ListingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductListing_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductListing_BusinessHoursTypeId",
                table: "ProductListing",
                column: "BusinessHoursTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductListing_ListingBusinessHoursId",
                table: "ProductListing",
                column: "ListingBusinessHoursId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductListing_ListingCategoryId",
                table: "ProductListing",
                column: "ListingCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductListing_ListingTypeId",
                table: "ProductListing",
                column: "ListingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductListing_UserProfileId",
                table: "ProductListing",
                column: "UserProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductListing");

            migrationBuilder.DropTable(
                name: "BusinessHoursType");

            migrationBuilder.DropTable(
                name: "ListingBusinessHours");

            migrationBuilder.DropTable(
                name: "ListingCategory");

            migrationBuilder.DropTable(
                name: "ListingType");
        }
    }
}
