using System.Collections.Generic;
using CringeLazer.Core.Models.Users;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CringeLazer.Bancho.Migrations
{
    public partial class AddHistoryJsonLists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<History>>(
                name: "monthly_playcounts",
                table: "user",
                type: "jsonb",
                nullable: false);

            migrationBuilder.AddColumn<List<History>>(
                name: "replays_watched",
                table: "user",
                type: "jsonb",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "monthly_playcounts",
                table: "user");

            migrationBuilder.DropColumn(
                name: "replays_watched",
                table: "user");
        }
    }
}
