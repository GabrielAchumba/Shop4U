using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop4U.Supermarkets.Migrations
{
    public partial class updatesupemarketFeb262020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("03052be6-4214-4faf-bca7-132553d16e15"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("0822f363-9600-4447-8a34-1cbb24c4e319"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("1cace482-d816-4d0d-8c1c-b2f9d298c8f2"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("56685aa3-e33b-4db5-8f5a-d6851c7f5a19"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("579c3159-539f-4d95-bcda-4cccbe96287b"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("60975055-160f-42f0-a0d6-313a32481615"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("806d0f1f-5181-42f4-bffe-4fa645628259"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("9d4a3515-5982-4b4d-882e-71f0654986db"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("d39f4440-e89d-4f47-a10f-75280ff17d00"));

            migrationBuilder.CreateTable(
                name: "ItemPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BackgrounndPicture = table.Column<byte[]>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CostPrice = table.Column<string>(nullable: true),
                    ItemId = table.Column<Guid>(nullable: false),
                    MarketId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPrices", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Supermarkets",
                columns: new[] { "Id", "BackgrounndPicture", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("a27db130-89a8-4851-9f64-46f56a28ae47"), null, "", "Shoprite" },
                    { new Guid("09a5240a-16f8-4cb0-a8e3-35e9aa39afb4"), null, "", "Justrite" },
                    { new Guid("aa4e5eb7-35ba-45a7-95cb-cb429ff9bf91"), null, "", "Welcome U" },
                    { new Guid("457d1e0b-d3c1-4c0f-8fda-e1461fa1c6d9"), null, "", "Livinchin" },
                    { new Guid("fd527ebb-8905-4467-9307-ae104314819d"), null, "", "Spar Mall" },
                    { new Guid("dcc47951-badc-4180-94bb-837f3506237f"), null, "", "Next Cash And Carry" },
                    { new Guid("e668f1db-c90b-41d2-866b-81aedf83eb61"), null, "", "Everyday" },
                    { new Guid("d30c3540-c163-4a4b-b12d-283c507f8f96"), null, "", "Market Square" },
                    { new Guid("09afec9e-7373-4f5e-ad2e-2154828fb7ef"), null, "", "PEP Store" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemPrices");

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("09a5240a-16f8-4cb0-a8e3-35e9aa39afb4"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("09afec9e-7373-4f5e-ad2e-2154828fb7ef"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("457d1e0b-d3c1-4c0f-8fda-e1461fa1c6d9"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("a27db130-89a8-4851-9f64-46f56a28ae47"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("aa4e5eb7-35ba-45a7-95cb-cb429ff9bf91"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("d30c3540-c163-4a4b-b12d-283c507f8f96"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("dcc47951-badc-4180-94bb-837f3506237f"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("e668f1db-c90b-41d2-866b-81aedf83eb61"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("fd527ebb-8905-4467-9307-ae104314819d"));

            migrationBuilder.InsertData(
                table: "Supermarkets",
                columns: new[] { "Id", "BackgrounndPicture", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0822f363-9600-4447-8a34-1cbb24c4e319"), null, "", "Shoprite" },
                    { new Guid("03052be6-4214-4faf-bca7-132553d16e15"), null, "", "Justrite" },
                    { new Guid("60975055-160f-42f0-a0d6-313a32481615"), null, "", "Welcome U" },
                    { new Guid("d39f4440-e89d-4f47-a10f-75280ff17d00"), null, "", "Livinchin" },
                    { new Guid("9d4a3515-5982-4b4d-882e-71f0654986db"), null, "", "Spar Mall" },
                    { new Guid("56685aa3-e33b-4db5-8f5a-d6851c7f5a19"), null, "", "Next Cash And Carry" },
                    { new Guid("579c3159-539f-4d95-bcda-4cccbe96287b"), null, "", "Everyday" },
                    { new Guid("806d0f1f-5181-42f4-bffe-4fa645628259"), null, "", "Market Square" },
                    { new Guid("1cace482-d816-4d0d-8c1c-b2f9d298c8f2"), null, "", "PEP Store" }
                });
        }
    }
}
