using Microsoft.EntityFrameworkCore.Migrations;

namespace Management.DataAccess.Migrations
{
    public partial class ChangeColumnNameCaseToStatusAtWorkAndNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Case",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "Case",
                table: "Notifications");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Works",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Notifications",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Notifications");

            migrationBuilder.AddColumn<bool>(
                name: "Case",
                table: "Works",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Case",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
