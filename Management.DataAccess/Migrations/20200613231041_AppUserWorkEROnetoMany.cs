using Microsoft.EntityFrameworkCore.Migrations;

namespace Management.DataAccess.Migrations
{
    public partial class AppUserWorkEROnetoMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Works",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Works_AppUserId",
                table: "Works",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_AspNetUsers_AppUserId",
                table: "Works",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_AspNetUsers_AppUserId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_AppUserId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");
        }
    }
}
