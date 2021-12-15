using Microsoft.EntityFrameworkCore.Migrations;

namespace KsiegarniaOnline.DataAccess.Migrations
{
    public partial class example : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Type",
                table: "Products",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "Cover",
                table: "Products",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "Category",
                table: "Products",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Category", "Cover", "Description", "ImageUrl", "InStock", "IsBestseller", "Pages", "Price", "Publisher", "Series", "Title", "Type", "Year" },
                values: new object[,]
                {
                    { 1, "aaa", (byte)0, (byte)0, "aaa", null, true, true, 10, 10.99m, "aaa", "aaa", "aaa", (byte)0, 10 },
                    { 2, "aaa", (byte)0, (byte)0, "aaa", null, true, true, 10, 10.99m, "aaa", "aaa", "aaa", (byte)0, 10 },
                    { 3, "aaa", (byte)0, (byte)0, "aaa", null, true, true, 10, 10.99m, "aaa", "aaa", "aaa", (byte)0, 10 },
                    { 4, "aaa", (byte)0, (byte)0, "aaa", null, true, true, 10, 10.99m, "aaa", "aaa", "aaa", (byte)0, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "Cover",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }
    }
}
