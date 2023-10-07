using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestHotelsDomain.Migrations
{
    public partial class DbReorganization4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Price_PriceList_PriceListId",
                table: "Price");

            migrationBuilder.AlterColumn<int>(
                name: "PriceListId",
                table: "Price",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Price_PriceList_PriceListId",
                table: "Price",
                column: "PriceListId",
                principalTable: "PriceList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Price_PriceList_PriceListId",
                table: "Price");

            migrationBuilder.AlterColumn<int>(
                name: "PriceListId",
                table: "Price",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Price_PriceList_PriceListId",
                table: "Price",
                column: "PriceListId",
                principalTable: "PriceList",
                principalColumn: "Id");
        }
    }
}
