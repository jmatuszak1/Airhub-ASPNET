using Microsoft.EntityFrameworkCore.Migrations;

namespace Airhub.Migrations
{
    public partial class pass1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Seat",
                table: "Passengers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seat",
                table: "Passengers");
        }
    }
}
