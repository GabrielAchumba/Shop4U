using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareForecasting.Migrations
{
    public partial class secondseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InputDeckDateStamp",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    InputDEckName = table.Column<string>(nullable: true),
                    DateOfCreation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputDeckDateStamp", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InputDeckDateStamp");
        }
    }
}
