using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop4U.Supermarkets.Migrations
{
    public partial class seeditems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "MarketGroup",
                table: "ItemPrices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MarketName",
                table: "ItemPrices",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "MarketGroup",
                table: "ItemPrices");

            migrationBuilder.DropColumn(
                name: "MarketName",
                table: "ItemPrices");

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
    }
}
