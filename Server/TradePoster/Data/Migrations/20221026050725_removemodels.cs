using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradePoster.Data.Migrations
{
    public partial class removemodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_Company_CompanyId",
                table: "UserProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_Packages_SubscriptionId",
                table: "UserProfile");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "ListingCategory");

            migrationBuilder.DropTable(
                name: "ListingReviews");

            migrationBuilder.DropTable(
                name: "ProductListingReactions");

            migrationBuilder.DropTable(
                name: "Testmonials");

            migrationBuilder.DropTable(
                name: "UserSubscriptionMatrix");

            migrationBuilder.DropTable(
                name: "BusinessHours");

            migrationBuilder.DropTable(
                name: "ProductListing");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "BusinessCategories");

            migrationBuilder.DropTable(
                name: "BusinessHoursType");

            migrationBuilder.DropTable(
                name: "ListingBusinessHours");

            migrationBuilder.DropTable(
                name: "ListingType");

            migrationBuilder.DropIndex(
                name: "IX_UserProfile_CompanyId",
                table: "UserProfile");

            migrationBuilder.DropIndex(
                name: "IX_UserProfile_SubscriptionId",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "UserProfile");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "UserProfile",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionId",
                table: "UserProfile",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BusinessCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridayFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FridayTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MondayFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MondayTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaturdayFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaturdayTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SundayFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SundayTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThursdayFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThursdayTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TuesdayFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TuesdayTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WednesdayFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WednesdayTo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessHours", x => x.Id);
                });

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
                    FridayFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FridayTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MondayFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MondayTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaturdayFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaturdayTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SundayFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SundayTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThursdayFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThursdayTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TuesdayFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TuesdayTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WednesdayFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WednesdayTo = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllowTags = table.Column<bool>(type: "bit", nullable: false),
                    BusinessHours = table.Column<bool>(type: "bit", nullable: false),
                    FeatureListing = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfImages = table.Column<int>(type: "int", nullable: false),
                    PackageExpiryDays = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: true),
                    RegularListing = table.Column<int>(type: "int", nullable: false),
                    SocialLinks = table.Column<bool>(type: "bit", nullable: false),
                    WebsiteLink = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Testmonials",
                columns: table => new
                {
                    TestmonialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testmonials", x => x.TestmonialID);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessHoursId = table.Column<int>(type: "int", nullable: true),
                    BusinessIndustryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_BusinessHours_BusinessHoursId",
                        column: x => x.BusinessHoursId,
                        principalTable: "BusinessHours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductListing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessHoursTypeId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ListingBusinessHoursId = table.Column<int>(type: "int", nullable: true),
                    ListingCategoryId = table.Column<int>(type: "int", nullable: true),
                    ListingTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ListingTypeId = table.Column<int>(type: "int", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoOfImages = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pictures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrevNoOfImages = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserProfileId = table.Column<int>(type: "int", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductListing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductListing_BusinessCategories_ListingCategoryId",
                        column: x => x.ListingCategoryId,
                        principalTable: "BusinessCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "UserSubscriptionMatrix",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureListing = table.Column<int>(type: "int", nullable: false),
                    NoOfImages = table.Column<int>(type: "int", nullable: false),
                    RegularListing = table.Column<int>(type: "int", nullable: false),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    userHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubscriptionMatrix", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSubscriptionMatrix_Packages_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSubscriptionMatrix_UserProfile_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListingReviews",
                columns: table => new
                {
                    ListingReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListingId = table.Column<int>(type: "int", nullable: false),
                    ReviewMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StarRating = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingReviews", x => x.ListingReviewId);
                    table.ForeignKey(
                        name: "FK_ListingReviews_ProductListing_ListingId",
                        column: x => x.ListingId,
                        principalTable: "ProductListing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductListingReactions",
                columns: table => new
                {
                    ReactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListingId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reaction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductListingReactions", x => x.ReactionId);
                    table.ForeignKey(
                        name: "FK_ProductListingReactions_ProductListing_ListingId",
                        column: x => x.ListingId,
                        principalTable: "ProductListing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_CompanyId",
                table: "UserProfile",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_SubscriptionId",
                table: "UserProfile",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_BusinessHoursId",
                table: "Company",
                column: "BusinessHoursId");

            migrationBuilder.CreateIndex(
                name: "IX_ListingReviews_ListingId",
                table: "ListingReviews",
                column: "ListingId");

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductListingReactions_ListingId",
                table: "ProductListingReactions",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubscriptionMatrix_SubscriptionId",
                table: "UserSubscriptionMatrix",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubscriptionMatrix_UserId",
                table: "UserSubscriptionMatrix",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_Company_CompanyId",
                table: "UserProfile",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_Packages_SubscriptionId",
                table: "UserProfile",
                column: "SubscriptionId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
