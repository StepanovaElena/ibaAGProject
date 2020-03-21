using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class AddColumnsToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CanBeDeleted",
                table: "Users",
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "CanBeDeleted",
                table: "Groups",
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanBeDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CanBeDeleted",
                table: "Groups");
        }
    }
}
