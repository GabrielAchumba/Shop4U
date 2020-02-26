using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop4U.Supermarkets.Migrations
{
    public partial class SeedUpdateItemsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ItemCartegoryId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemGroupId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemTypeId",
                table: "Items");

            migrationBuilder.AddColumn<string>(
                name: "ItemCartegoryName",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemGroupName",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemTypeName",
                table: "Items",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ItemCartegoryName",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemGroupName",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemTypeName",
                table: "Items");

            migrationBuilder.AddColumn<Guid>(
                name: "ItemCartegoryId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ItemGroupId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ItemTypeId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}
