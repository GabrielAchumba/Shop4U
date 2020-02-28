using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop4U.Supermarkets.Migrations
{
    public partial class seedsupermarketcarts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("19f4bdea-a7f6-4803-8f7d-de95da49fb8d"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("3e3ece94-30dc-480f-9fd8-7e50b5587719"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("4a0852da-ca41-4387-827c-20f30cbfa5be"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("6d73fcf8-794c-4117-9dd2-ab4a668221c1"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("7342bfed-e656-4f76-8c57-89d6ae42d6e5"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("75abef9c-cf02-4227-bc5b-6b7f7ba7a3d0"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("ab39862b-6bb0-4280-9f45-e9e21777fcc5"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("c996e182-f008-4696-ba12-b2406fec308d"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("e9d8c926-1421-4b4b-8c8a-add641f9e13f"));

            migrationBuilder.CreateTable(
                name: "SupermarketCarts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BackgrounndPicture = table.Column<byte[]>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Day = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    ItemName = table.Column<string>(nullable: true),
                    MarketName = table.Column<string>(nullable: true),
                    CostPrice = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupermarketCarts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Supermarkets",
                columns: new[] { "Id", "BackgrounndPicture", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("9e173733-fee9-4c03-b719-6614c78f2618"), null, "", "Shoprite" },
                    { new Guid("6b39800f-7cae-4d76-957c-f95ed04e2c10"), null, "", "Justrite" },
                    { new Guid("7848fd09-2957-4c68-a433-dbe826e836cb"), null, "", "Welcome U" },
                    { new Guid("1fc46233-1f04-4b4f-a46f-79d7813c4df5"), null, "", "Livinchin" },
                    { new Guid("b75b7260-eee6-44d1-8b54-0ef2943ea6b5"), null, "", "Spar Mall" },
                    { new Guid("4bccb405-dea9-46e0-a018-8b9892d6d3ad"), null, "", "Next Cash And Carry" },
                    { new Guid("bcc2b041-ff5c-41f3-8d49-6a7ac83a19b4"), null, "", "Everyday" },
                    { new Guid("28f0b9ed-1289-4b81-9669-b3dd5469d7c2"), null, "", "Market Square" },
                    { new Guid("0dc0a576-a1a1-461c-a6cf-5c0138f612a9"), null, "", "PEP Store" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupermarketCarts");

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("0dc0a576-a1a1-461c-a6cf-5c0138f612a9"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("1fc46233-1f04-4b4f-a46f-79d7813c4df5"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("28f0b9ed-1289-4b81-9669-b3dd5469d7c2"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("4bccb405-dea9-46e0-a018-8b9892d6d3ad"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("6b39800f-7cae-4d76-957c-f95ed04e2c10"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("7848fd09-2957-4c68-a433-dbe826e836cb"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("9e173733-fee9-4c03-b719-6614c78f2618"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("b75b7260-eee6-44d1-8b54-0ef2943ea6b5"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("bcc2b041-ff5c-41f3-8d49-6a7ac83a19b4"));

            migrationBuilder.InsertData(
                table: "Supermarkets",
                columns: new[] { "Id", "BackgrounndPicture", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("e9d8c926-1421-4b4b-8c8a-add641f9e13f"), null, "", "Shoprite" },
                    { new Guid("6d73fcf8-794c-4117-9dd2-ab4a668221c1"), null, "", "Justrite" },
                    { new Guid("4a0852da-ca41-4387-827c-20f30cbfa5be"), null, "", "Welcome U" },
                    { new Guid("75abef9c-cf02-4227-bc5b-6b7f7ba7a3d0"), null, "", "Livinchin" },
                    { new Guid("3e3ece94-30dc-480f-9fd8-7e50b5587719"), null, "", "Spar Mall" },
                    { new Guid("19f4bdea-a7f6-4803-8f7d-de95da49fb8d"), null, "", "Next Cash And Carry" },
                    { new Guid("7342bfed-e656-4f76-8c57-89d6ae42d6e5"), null, "", "Everyday" },
                    { new Guid("ab39862b-6bb0-4280-9f45-e9e21777fcc5"), null, "", "Market Square" },
                    { new Guid("c996e182-f008-4696-ba12-b2406fec308d"), null, "", "PEP Store" }
                });
        }
    }
}
