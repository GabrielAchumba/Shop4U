using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop4U.Supermarkets.Migrations
{
    public partial class SeedSupermarkets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemCartegories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BackgrounndPicture = table.Column<byte[]>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCartegories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BackgrounndPicture = table.Column<byte[]>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BackgrounndPicture = table.Column<byte[]>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ItemCartegoryId = table.Column<Guid>(nullable: false),
                    ItemGroupId = table.Column<Guid>(nullable: false),
                    ItemTypeId = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BackgrounndPicture = table.Column<byte[]>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supermarkets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BackgrounndPicture = table.Column<byte[]>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supermarkets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Supermarkets",
                columns: new[] { "Id", "BackgrounndPicture", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("21b2803e-edc6-43a2-a4b3-9c373746107d"), null, "", "Shoprite" },
                    { new Guid("d74fa74b-6004-4fe0-b6fe-f640e4882718"), null, "", "Justrite" },
                    { new Guid("99728f1c-025a-4936-ab5f-496cf6a5a941"), null, "", "Welcome U" },
                    { new Guid("b8e31a91-219f-4400-adac-78139a6c60e1"), null, "", "Livinchin" },
                    { new Guid("6cec792b-b744-4619-85c4-c39a14da5df6"), null, "", "Spar Mall" },
                    { new Guid("d2396491-e87a-4cb2-9854-eaf2ebfc1464"), null, "", "Next Cash And Carry" },
                    { new Guid("f508e8a1-86b5-45aa-b207-44fb748f8ece"), null, "", "Everyday" },
                    { new Guid("47a2a286-99ba-46a1-b812-b028497c8ca0"), null, "", "Market Square" },
                    { new Guid("9f14d4bf-51b9-4e24-8105-3fcd1fb68a38"), null, "", "PEP Store" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCartegories");

            migrationBuilder.DropTable(
                name: "ItemGroups");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropTable(
                name: "Supermarkets");
        }
    }
}
