using Microsoft.EntityFrameworkCore.Migrations;

namespace Confectionery.DAL.EF.Migrations
{
    class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,] {
                    { 1, "Cookies"},
                    { 2, "Chocolate"}
                });
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Description", "CategoryId", "Price" },
                values: new object[,] {
                    { 1, "Cookies1", "Amazing cookies", 1, 42},
                    { 2, "Cookies2", "Even more amazing cookies", 1, 44.4},
                    { 3, "Chocolate1", "Explosion of taste", 2, 90.1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3 });
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValues: new object [] { 1, 2 });
        }
    }
}
