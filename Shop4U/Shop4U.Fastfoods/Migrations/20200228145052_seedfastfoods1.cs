using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop4U.Fastfoods.Migrations
{
    public partial class seedfastfoods1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FastfoodCarts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BackgrounndPicture = table.Column<byte[]>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Base64String = table.Column<string>(nullable: true),
                    Day = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    ItemName = table.Column<string>(nullable: true),
                    MarketName = table.Column<string>(nullable: true),
                    CostPrice = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FastfoodCarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FastfoodItemPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BackgrounndPicture = table.Column<byte[]>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Base64String = table.Column<string>(nullable: true),
                    CostPrice = table.Column<string>(nullable: true),
                    ItemId = table.Column<Guid>(nullable: false),
                    MarketId = table.Column<Guid>(nullable: false),
                    MarketGroup = table.Column<string>(nullable: true),
                    MarketName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FastfoodItemPrices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FastfoodItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BackgrounndPicture = table.Column<byte[]>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Base64String = table.Column<string>(nullable: true),
                    ItemCartegoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FastfoodItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fastfoods",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BackgrounndPicture = table.Column<byte[]>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Base64String = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fastfoods", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Fastfoods",
                columns: new[] { "Id", "BackgrounndPicture", "Base64String", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("d7211094-cf03-4e25-b2fb-0769eb887904"), null, null, "", "Chicken Republic" },
                    { new Guid("8b586308-d72f-4e76-8f77-b56d55b0c453"), null, null, "", "Kilimanjaro" },
                    { new Guid("b38a5743-3bc5-431d-a0d2-aa87e51fc5fb"), null, null, "", "Pizzamore" },
                    { new Guid("ba143144-2e04-4b06-b4bd-468f45b6f031"), null, null, "", "Genesis" },
                    { new Guid("b8503747-bcfa-4e87-a17f-1a4f0d9fb8e4"), null, null, "", "Bole King" },
                    { new Guid("d62be45f-2fe9-45a6-b817-03b1642b173f"), null, null, "", "The Promise" },
                    { new Guid("48115936-30c9-4350-9b1e-4746784d7cfe"), null, null, "", "BestBite" },
                    { new Guid("71355cb2-3c2c-4f50-9282-42b8d3005c6b"), null, null, "", "Native Tray" },
                    { new Guid("68a761aa-e5b9-43b4-b92e-2e2e9dbe7857"), null, null, "", "Sweet Tooth" },
                    { new Guid("379e4605-0048-4868-8174-7ff0bfac9374"), null, null, "", "ColdStone" },
                    { new Guid("cab6d3f8-4c87-4df9-ad53-1ae4e25ead09"), null, null, "", "Jevinik" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FastfoodCarts");

            migrationBuilder.DropTable(
                name: "FastfoodItemPrices");

            migrationBuilder.DropTable(
                name: "FastfoodItems");

            migrationBuilder.DropTable(
                name: "Fastfoods");
        }
    }
}
