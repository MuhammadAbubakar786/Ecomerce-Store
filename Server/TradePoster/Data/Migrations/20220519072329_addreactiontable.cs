using Microsoft.EntityFrameworkCore.Migrations;

namespace TradePoster.Data.Migrations
{
    public partial class addreactiontable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSubscriptionMatrix_Packages_SubscriptionId",
                table: "UserSubscriptionMatrix");

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionId",
                table: "UserSubscriptionMatrix",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductListingReactions_ListingId",
                table: "ProductListingReactions",
                column: "ListingId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubscriptionMatrix_Packages_SubscriptionId",
                table: "UserSubscriptionMatrix",
                column: "SubscriptionId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSubscriptionMatrix_Packages_SubscriptionId",
                table: "UserSubscriptionMatrix");

            migrationBuilder.DropTable(
                name: "ProductListingReactions");

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionId",
                table: "UserSubscriptionMatrix",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubscriptionMatrix_Packages_SubscriptionId",
                table: "UserSubscriptionMatrix",
                column: "SubscriptionId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
