using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop4U.Supermarkets.Migrations
{
    public partial class SeedSupermarketCloudTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Supermarkets",
                columns: new[] { "Id", "BackgrounndPicture", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("6ec7e84a-7fb6-4c0f-822d-724182caefd4"), null, "", "Shoprite" },
                    { new Guid("d3dbf9f5-a2ea-410b-a71e-8f8ea4f3bd2b"), null, "", "Justrite" },
                    { new Guid("df44fcf9-a8e5-48f7-a7c1-d0c1c0d9f4b2"), null, "", "Welcome U" },
                    { new Guid("56cf7b0d-f324-4f1c-a171-ac0749853f21"), null, "", "Livinchin" },
                    { new Guid("e99e4558-2f67-4fa5-b192-50c4a791a16a"), null, "", "Spar Mall" },
                    { new Guid("38e60ab0-c7a4-4074-a0f3-ffb897246ff2"), null, "", "Next Cash And Carry" },
                    { new Guid("ab20d250-1a7a-4d58-b790-c5eb9e67e896"), null, "", "Everyday" },
                    { new Guid("0bed3778-d675-4e82-a08d-2919e364827f"), null, "", "Market Square" },
                    { new Guid("61302577-1750-4d47-b5a3-5d86615ea4de"), null, "", "PEP Store" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("0bed3778-d675-4e82-a08d-2919e364827f"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("38e60ab0-c7a4-4074-a0f3-ffb897246ff2"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("56cf7b0d-f324-4f1c-a171-ac0749853f21"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("61302577-1750-4d47-b5a3-5d86615ea4de"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("6ec7e84a-7fb6-4c0f-822d-724182caefd4"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("ab20d250-1a7a-4d58-b790-c5eb9e67e896"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("d3dbf9f5-a2ea-410b-a71e-8f8ea4f3bd2b"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("df44fcf9-a8e5-48f7-a7c1-d0c1c0d9f4b2"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("e99e4558-2f67-4fa5-b192-50c4a791a16a"));

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
    }
}
