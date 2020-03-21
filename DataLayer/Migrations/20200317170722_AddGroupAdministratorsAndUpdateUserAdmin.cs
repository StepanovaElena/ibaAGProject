using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class AddGroupAdministratorsAndUpdateUserAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Name", "CanBeDeleted" },
                values: new object[] { "Administrators", false });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CanBeDeleted",
                value: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
