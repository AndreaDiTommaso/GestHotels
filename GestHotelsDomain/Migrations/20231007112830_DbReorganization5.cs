using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestHotelsDomain.Migrations
{
    public partial class DbReorganization5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_Hotel_HotelId",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_PriceList_PriceListId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_PriceListId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Price_PriceListId",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "PriceListId",
                table: "Room");

            migrationBuilder.AlterColumn<int>(
                name: "HotelId",
                table: "Room",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "PriceList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "IX_UniqueKeyConstraint",
                table: "Price",
                columns: new[] { "PriceListId", "Date" });

            migrationBuilder.CreateIndex(
                name: "IX_PriceList_RoomId",
                table: "PriceList",
                column: "RoomId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceList_Room_RoomId",
                table: "PriceList",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Hotel_HotelId",
                table: "Room",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceList_Room_RoomId",
                table: "PriceList");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Hotel_HotelId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_PriceList_RoomId",
                table: "PriceList");

            migrationBuilder.DropUniqueConstraint(
                name: "IX_UniqueKeyConstraint",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "PriceList");

            migrationBuilder.AlterColumn<int>(
                name: "HotelId",
                table: "Room",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PriceListId",
                table: "Room",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Room_PriceListId",
                table: "Room",
                column: "PriceListId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_PriceListId",
                table: "Price",
                column: "PriceListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Hotel_HotelId",
                table: "Room",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_PriceList_PriceListId",
                table: "Room",
                column: "PriceListId",
                principalTable: "PriceList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
