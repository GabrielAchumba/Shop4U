using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop4U.Supermarkets.Migrations
{
    public partial class seedsupermarketcarts3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Base64String",
                table: "Supermarkets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Base64String",
                table: "SupermarketCarts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Base64String",
                table: "ItemTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Base64String",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Base64String",
                table: "ItemPrices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Base64String",
                table: "ItemGroups",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Base64String",
                table: "ItemCartegories",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Supermarkets",
                columns: new[] { "Id", "BackgrounndPicture", "Base64String", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("becd140f-8731-419e-a0fe-cde99c2ada5b"), null, null, "", "Shoprite" },
                    { new Guid("394291e9-ab8f-47c9-b134-4fbc97f18fbe"), null, null, "", "Justrite" },
                    { new Guid("b75b01e0-bb24-4369-8cdc-48581ebfd52b"), null, null, "", "Welcome U" },
                    { new Guid("8f1e4822-1607-4642-a520-2f1a02b24bfb"), null, null, "", "Livinchin" },
                    { new Guid("69f0c70a-c5a2-4669-87f2-361097a90126"), null, null, "", "Spar Mall" },
                    { new Guid("d90d012e-866d-4ebb-9499-4283831e6f3e"), null, null, "", "Next Cash And Carry" },
                    { new Guid("bb9f7396-b694-4e82-accd-fb144460f581"), null, null, "", "Everyday" },
                    { new Guid("9fdfa74a-f892-4a18-b65b-7f82495a0da7"), null, null, "", "Market Square" },
                    { new Guid("b924c652-bc77-4d46-ab85-65f822487588"), null, null, "", "PEP Store" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("394291e9-ab8f-47c9-b134-4fbc97f18fbe"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("69f0c70a-c5a2-4669-87f2-361097a90126"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("8f1e4822-1607-4642-a520-2f1a02b24bfb"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("9fdfa74a-f892-4a18-b65b-7f82495a0da7"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("b75b01e0-bb24-4369-8cdc-48581ebfd52b"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("b924c652-bc77-4d46-ab85-65f822487588"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("bb9f7396-b694-4e82-accd-fb144460f581"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("becd140f-8731-419e-a0fe-cde99c2ada5b"));

            migrationBuilder.DeleteData(
                table: "Supermarkets",
                keyColumn: "Id",
                keyValue: new Guid("d90d012e-866d-4ebb-9499-4283831e6f3e"));

            migrationBuilder.DropColumn(
                name: "Base64String",
                table: "Supermarkets");

            migrationBuilder.DropColumn(
                name: "Base64String",
                table: "SupermarketCarts");

            migrationBuilder.DropColumn(
                name: "Base64String",
                table: "ItemTypes");

            migrationBuilder.DropColumn(
                name: "Base64String",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Base64String",
                table: "ItemPrices");

            migrationBuilder.DropColumn(
                name: "Base64String",
                table: "ItemGroups");

            migrationBuilder.DropColumn(
                name: "Base64String",
                table: "ItemCartegories");

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
    }
}
