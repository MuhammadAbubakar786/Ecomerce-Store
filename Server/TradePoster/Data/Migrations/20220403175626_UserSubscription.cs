using Microsoft.EntityFrameworkCore.Migrations;

namespace TradePoster.Data.Migrations
{
    public partial class UserSubscription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubscriptionId",
                table: "UserProfile",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserSubscriptionMatrix",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoOfImages = table.Column<int>(type: "int", nullable: false),
                    RegularListing = table.Column<int>(type: "int", nullable: false),
                    FeatureListing = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    SubscriptionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubscriptionMatrix", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSubscriptionMatrix_Packages_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSubscriptionMatrix_UserProfile_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_SubscriptionId",
                table: "UserProfile",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubscriptionMatrix_SubscriptionId",
                table: "UserSubscriptionMatrix",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubscriptionMatrix_UserId",
                table: "UserSubscriptionMatrix",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_Packages_SubscriptionId",
                table: "UserProfile",
                column: "SubscriptionId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_Packages_SubscriptionId",
                table: "UserProfile");

            migrationBuilder.DropTable(
                name: "UserSubscriptionMatrix");

            migrationBuilder.DropIndex(
                name: "IX_UserProfile_SubscriptionId",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "UserProfile");
        }
    }
}
