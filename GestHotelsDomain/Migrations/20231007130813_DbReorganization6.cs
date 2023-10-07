using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestHotelsDomain.Migrations
{
    public partial class DbReorganization6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_RoomType_TypeId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_TypeId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Room");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "RoomType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RoomType_RoomId",
                table: "RoomType",
                column: "RoomId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomType_Room_RoomId",
                table: "RoomType",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomType_Room_RoomId",
                table: "RoomType");

            migrationBuilder.DropIndex(
                name: "IX_RoomType_RoomId",
                table: "RoomType");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "RoomType");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Room",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Room_TypeId",
                table: "Room",
                column: "TypeId");

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
