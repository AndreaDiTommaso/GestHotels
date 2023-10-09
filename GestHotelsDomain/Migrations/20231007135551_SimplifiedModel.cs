using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestHotelsDomain.Migrations
{
    public partial class SimplifiedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Price_PriceList_PriceListId",
                table: "Price");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomType_Room_RoomId",
                table: "RoomType");

            migrationBuilder.DropTable(
                name: "PriceList");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropIndex(
                name: "IX_RoomType_RoomId",
                table: "RoomType");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "RoomType",
                newName: "UpperBound");

            migrationBuilder.RenameColumn(
                name: "PriceListId",
                table: "Price",
                newName: "RoomTypeId");

            migrationBuilder.AddColumn<int>(
                name: "Cardnality",
                table: "RoomType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "RoomType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LowerBound",
                table: "RoomType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TypeName",
                table: "RoomType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_RoomType_HotelId",
                table: "RoomType",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Price_RoomType_RoomTypeId",
                table: "Price",
                column: "RoomTypeId",
                principalTable: "RoomType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomType_Hotel_HotelId",
                table: "RoomType",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Price_RoomType_RoomTypeId",
                table: "Price");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomType_Hotel_HotelId",
                table: "RoomType");

            migrationBuilder.DropIndex(
                name: "IX_RoomType_HotelId",
                table: "RoomType");

            migrationBuilder.DropColumn(
                name: "Cardnality",
                table: "RoomType");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "RoomType");

            migrationBuilder.DropColumn(
                name: "LowerBound",
                table: "RoomType");

            migrationBuilder.DropColumn(
                name: "TypeName",
                table: "RoomType");

            migrationBuilder.RenameColumn(
                name: "UpperBound",
                table: "RoomType",
                newName: "RoomId");

            migrationBuilder.RenameColumn(
                name: "RoomTypeId",
                table: "Price",
                newName: "PriceListId");

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceList_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomType_RoomId",
                table: "RoomType",
                column: "RoomId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PriceList_RoomId",
                table: "PriceList",
                column: "RoomId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Room_HotelId",
                table: "Room",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Price_PriceList_PriceListId",
                table: "Price",
                column: "PriceListId",
                principalTable: "PriceList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomType_Room_RoomId",
                table: "RoomType",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
