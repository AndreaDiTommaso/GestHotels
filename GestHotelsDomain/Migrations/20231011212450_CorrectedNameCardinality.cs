using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestHotelsDomain.Migrations
{
    public partial class CorrectedNameCardinality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cardnality",
                table: "RoomType",
                newName: "Cardinality");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cardinality",
                table: "RoomType",
                newName: "Cardnality");
        }
    }
}
