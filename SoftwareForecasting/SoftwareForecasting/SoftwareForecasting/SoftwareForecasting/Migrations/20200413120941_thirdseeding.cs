using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareForecasting.Migrations
{
    public partial class thirdseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InputDEckName",
                table: "InputDeckDateStamp",
                newName: "InputDeckName");

            migrationBuilder.AddColumn<Guid>(
                name: "InputDeckId",
                table: "InputDecks",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "InputDeckId",
                table: "FacilityDecks",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InputDeckId",
                table: "InputDecks");

            migrationBuilder.DropColumn(
                name: "InputDeckId",
                table: "FacilityDecks");

            migrationBuilder.RenameColumn(
                name: "InputDeckName",
                table: "InputDeckDateStamp",
                newName: "InputDEckName");
        }
    }
}
