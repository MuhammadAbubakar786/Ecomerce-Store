using Microsoft.EntityFrameworkCore.Migrations;

namespace TradePoster.Data.Migrations
{
    public partial class updatedBusinessHours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_BusinessHours_BusinessHoursId",
                table: "UserProfile");

            migrationBuilder.DropIndex(
                name: "IX_UserProfile_BusinessHoursId",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "BusinessHoursId",
                table: "UserProfile");

            migrationBuilder.AddColumn<int>(
                name: "BusinessHoursId",
                table: "Company",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_BusinessHoursId",
                table: "Company",
                column: "BusinessHoursId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_BusinessHours_BusinessHoursId",
                table: "Company",
                column: "BusinessHoursId",
                principalTable: "BusinessHours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_BusinessHours_BusinessHoursId",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_BusinessHoursId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "BusinessHoursId",
                table: "Company");

            migrationBuilder.AddColumn<int>(
                name: "BusinessHoursId",
                table: "UserProfile",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_BusinessHoursId",
                table: "UserProfile",
                column: "BusinessHoursId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_BusinessHours_BusinessHoursId",
                table: "UserProfile",
                column: "BusinessHoursId",
                principalTable: "BusinessHours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
