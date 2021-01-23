using Microsoft.EntityFrameworkCore.Migrations;

namespace Airhub.Migrations
{
    public partial class ticket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seat",
                table: "Passengers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Seat",
                table: "Passengers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
