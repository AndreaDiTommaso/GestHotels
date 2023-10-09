using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestHotelsDomain.Migrations
{
    public partial class SimplifiedModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpperBound",
                table: "RoomType",
                newName: "TopMarginPercentage");

            migrationBuilder.RenameColumn(
                name: "LowerBound",
                table: "RoomType",
                newName: "DownMarginPercentage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TopMarginPercentage",
                table: "RoomType",
                newName: "UpperBound");

            migrationBuilder.RenameColumn(
                name: "DownMarginPercentage",
                table: "RoomType",
                newName: "LowerBound");
        }
    }
}
