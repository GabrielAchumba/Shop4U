using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop4U.Supermarkets.Migrations
{
    public partial class SeedSupermarketsAzureTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("60509b3a-538b-42c2-a534-befec70dc10c"), null, "", "Shoprite" },
                    { new Guid("5d84e289-403d-462c-a5e6-e94bf6367b21"), null, "", "Justrite" },
                    { new Guid("74411a7a-68fc-42bd-8e06-e5853e5050fb"), null, "", "Welcome U" },
                    { new Guid("1c647d3e-ac22-4d4f-aa79-124d3313dd12"), null, "", "Livinchin" },
                    { new Guid("5ce56483-7880-48ac-ba59-8d0dcd8a68be"), null, "", "Spar Mall" },
                    { new Guid("c60d06f0-f0a6-4021-a481-ea1d5f3d144a"), null, "", "Next Cash And Carry" },
                    { new Guid("29aed2e5-bcf1-456f-80b8-567a04f8df76"), null, "", "Everyday" },
                    { new Guid("118a4259-d437-442f-9fe5-319e6eb11095"), null, "", "Market Square" },
                    { new Guid("f3849403-d167-4e26-afb2-a597fa203711"), null, "", "PEP Store" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("118a4259-d437-442f-9fe5-319e6eb11095"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("1c647d3e-ac22-4d4f-aa79-124d3313dd12"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("29aed2e5-bcf1-456f-80b8-567a04f8df76"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("5ce56483-7880-48ac-ba59-8d0dcd8a68be"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("5d84e289-403d-462c-a5e6-e94bf6367b21"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("60509b3a-538b-42c2-a534-befec70dc10c"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("74411a7a-68fc-42bd-8e06-e5853e5050fb"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("c60d06f0-f0a6-4021-a481-ea1d5f3d144a"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("f3849403-d167-4e26-afb2-a597fa203711"));

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
    }
}
