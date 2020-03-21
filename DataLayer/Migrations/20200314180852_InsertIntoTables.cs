using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class InsertIntoTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Name" },
                values: new object[,]
                {
                    { "Manage Users" },
                    { "Manage Datasourses" },
                    { "View Dashboards" },
                    { "Edit Dashboards" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Login" , "Password", "Email" },
                values: new object[] {"admin", "123456", "admin@mail.ru"});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
