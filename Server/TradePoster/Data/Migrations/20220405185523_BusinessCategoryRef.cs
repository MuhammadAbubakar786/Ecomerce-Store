using Microsoft.EntityFrameworkCore.Migrations;

namespace TradePoster.Data.Migrations
{
    public partial class BusinessCategoryRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductListing_ListingCategory_ListingCategoryId",
                table: "ProductListing");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductListing_BusinessCategories_ListingCategoryId",
                table: "ProductListing",
                column: "ListingCategoryId",
                principalTable: "BusinessCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductListing_BusinessCategories_ListingCategoryId",
                table: "ProductListing");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductListing_ListingCategory_ListingCategoryId",
                table: "ProductListing",
                column: "ListingCategoryId",
                principalTable: "ListingCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
