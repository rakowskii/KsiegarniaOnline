using Microsoft.EntityFrameworkCore.Migrations;

namespace KsiegarniaOnline.DataAccess.Migrations
{
    public partial class Properties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Types",
                table: "Products",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Covers",
                table: "Products",
                newName: "Cover");

            migrationBuilder.RenameColumn(
                name: "Categories",
                table: "Products",
                newName: "Category");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Products",
                newName: "Types");

            migrationBuilder.RenameColumn(
                name: "Cover",
                table: "Products",
                newName: "Covers");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Products",
                newName: "Categories");
        }
    }
}
