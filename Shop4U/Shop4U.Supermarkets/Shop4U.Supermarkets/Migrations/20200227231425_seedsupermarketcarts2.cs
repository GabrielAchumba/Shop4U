using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop4U.Supermarkets.Migrations
{
    public partial class seedsupermarketcarts2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "SupermarketCarts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "SupermarketCarts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Supermarkets",
                columns: new[] { "Id", "BackgrounndPicture", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("fb0d4bee-d24b-4c41-a518-8eeebd62d34f"), null, "", "Shoprite" },
                    { new Guid("6e9878d1-b6b0-4e35-8f35-5f8d1346410e"), null, "", "Justrite" },
                    { new Guid("2775f8d4-bb30-43c0-b2f1-335e9abfa7cc"), null, "", "Welcome U" },
                    { new Guid("70850463-705d-4c0b-9abb-051274e7108d"), null, "", "Livinchin" },
                    { new Guid("9261fd44-d4ff-4119-a42c-cc7ed9e869e2"), null, "", "Spar Mall" },
                    { new Guid("ac8e047e-e093-4e4a-ac21-445eb06429e2"), null, "", "Next Cash And Carry" },
                    { new Guid("786220aa-e27c-4073-859c-f1f2a27ca4fa"), null, "", "Everyday" },
                    { new Guid("d89e89f8-b022-4413-93eb-1e97857546f0"), null, "", "Market Square" },
                    { new Guid("302df909-f09d-4e3a-b99c-fe23b8e8f29f"), null, "", "PEP Store" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("2775f8d4-bb30-43c0-b2f1-335e9abfa7cc"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("302df909-f09d-4e3a-b99c-fe23b8e8f29f"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("6e9878d1-b6b0-4e35-8f35-5f8d1346410e"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("70850463-705d-4c0b-9abb-051274e7108d"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("786220aa-e27c-4073-859c-f1f2a27ca4fa"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("9261fd44-d4ff-4119-a42c-cc7ed9e869e2"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("ac8e047e-e093-4e4a-ac21-445eb06429e2"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("d89e89f8-b022-4413-93eb-1e97857546f0"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("fb0d4bee-d24b-4c41-a518-8eeebd62d34f"));

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "SupermarketCarts");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "SupermarketCarts");

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
    }
}
