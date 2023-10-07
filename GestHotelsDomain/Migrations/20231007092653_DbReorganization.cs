using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestHotelsDomain.Migrations
{
    public partial class DbReorganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_PriceList_PriceListId",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_RoomType_TypeId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_PriceListId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "PriceListId",
                table: "Room");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Room",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Room_TypeId",
                table: "Room",
                newName: "IX_Room_RoomId");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "RoomType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "PriceList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_PriceList_RoomId",
                table: "Room",
                column: "RoomId",
                principalTable: "PriceList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_RoomType_RoomId",
                table: "Room",
                column: "RoomId",
                principalTable: "RoomType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_PriceList_RoomId",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_RoomType_RoomId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "RoomType");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "PriceList");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Room",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Room_RoomId",
                table: "Room",
                newName: "IX_Room_TypeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Room_PriceList_PriceListId",
                table: "Room",
                column: "PriceListId",
                principalTable: "PriceList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_RoomType_TypeId",
                table: "Room",
                column: "TypeId",
                principalTable: "RoomType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
