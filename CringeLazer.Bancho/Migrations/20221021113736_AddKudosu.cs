using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CringeLazer.Bancho.Migrations
{
    public partial class AddKudosu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "kudosu_available",
                table: "user",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "kudosu_total",
                table: "user",
                type: "integer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "kudosu_available",
                table: "user");

            migrationBuilder.DropColumn(
                name: "kudosu_total",
                table: "user");
        }
    }
}
