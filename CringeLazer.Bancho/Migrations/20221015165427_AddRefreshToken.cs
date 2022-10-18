using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CringeLazer.Bancho.Migrations
{
    public partial class AddRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "refresh_token",
                table: "user",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_refresh_token",
                table: "user",
                column: "refresh_token",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_refresh_token",
                table: "user");

            migrationBuilder.DropColumn(
                name: "refresh_token",
                table: "user");
        }
    }
}
