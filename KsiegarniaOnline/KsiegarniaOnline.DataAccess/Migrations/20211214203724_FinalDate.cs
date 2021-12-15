using Microsoft.EntityFrameworkCore.Migrations;

namespace KsiegarniaOnline.DataAccess.Migrations
{
    public partial class FinalDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddTime",
                table: "Reviews",
                newName: "AddDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddDate",
                table: "Reviews",
                newName: "AddTime");
        }
    }
}
