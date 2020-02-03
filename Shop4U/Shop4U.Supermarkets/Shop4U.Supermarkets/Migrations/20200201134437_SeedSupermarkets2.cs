using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop4U.Supermarkets.Migrations
{
    public partial class SeedSupermarkets2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("21b2803e-edc6-43a2-a4b3-9c373746107d"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("47a2a286-99ba-46a1-b812-b028497c8ca0"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("6cec792b-b744-4619-85c4-c39a14da5df6"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("99728f1c-025a-4936-ab5f-496cf6a5a941"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("9f14d4bf-51b9-4e24-8105-3fcd1fb68a38"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("b8e31a91-219f-4400-adac-78139a6c60e1"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("d2396491-e87a-4cb2-9854-eaf2ebfc1464"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("d74fa74b-6004-4fe0-b6fe-f640e4882718"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("f508e8a1-86b5-45aa-b207-44fb748f8ece"));

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Items",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "Supermarkets",
                columns: new[] { "Id", "BackgrounndPicture", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("4c014f70-28be-47c9-822e-41440df52587"), null, "", "Shoprite" },
                    { new Guid("a6839118-7bea-4a06-beae-02296c1fe3d8"), null, "", "Justrite" },
                    { new Guid("ae7852a0-ff22-47f6-9600-48d916fdb033"), null, "", "Welcome U" },
                    { new Guid("90c39ddf-06a9-42ba-8f72-f1cd828d40f1"), null, "", "Livinchin" },
                    { new Guid("a3d41ead-a606-4cf3-b5a5-ad1da5ed0dce"), null, "", "Spar Mall" },
                    { new Guid("c45ee5ff-14a7-43db-aedc-6d39afabac2e"), null, "", "Next Cash And Carry" },
                    { new Guid("07a19635-521c-4eff-a343-06f230675b4b"), null, "", "Everyday" },
                    { new Guid("e8c07b11-45c4-4cee-8e32-f22c9e5ad351"), null, "", "Market Square" },
                    { new Guid("46e8b142-db06-4343-9eae-6783cb0676d4"), null, "", "PEP Store" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("07a19635-521c-4eff-a343-06f230675b4b"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("46e8b142-db06-4343-9eae-6783cb0676d4"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("4c014f70-28be-47c9-822e-41440df52587"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("90c39ddf-06a9-42ba-8f72-f1cd828d40f1"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("a3d41ead-a606-4cf3-b5a5-ad1da5ed0dce"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("a6839118-7bea-4a06-beae-02296c1fe3d8"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("ae7852a0-ff22-47f6-9600-48d916fdb033"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("c45ee5ff-14a7-43db-aedc-6d39afabac2e"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("e8c07b11-45c4-4cee-8e32-f22c9e5ad351"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double));

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
    }
}
