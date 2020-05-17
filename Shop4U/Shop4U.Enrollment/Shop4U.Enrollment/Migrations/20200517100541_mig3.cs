using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop4U.Enrollment.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SuperAdministrators",
                keyColumn: "Id",
                keyValue: new Guid("2837d875-aa14-4f3c-a09a-6c00c840682a"));

            migrationBuilder.AddColumn<string>(
                name: "ItemCategory",
                table: "GoodDetails",
                nullable: true);

            migrationBuilder.InsertData(
                table: "SuperAdministrators",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "PhoneNumber", "UserName", "UserType" },
                values: new object[] { new Guid("9f075c51-c89e-4dcd-8b84-2f0c98d19c6d"), "SuperAdmin1", "SuperAdmin1", "superadmin1", null, "superAdmin1", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SuperAdministrators",
                keyColumn: "Id",
                keyValue: new Guid("9f075c51-c89e-4dcd-8b84-2f0c98d19c6d"));

            migrationBuilder.DropColumn(
                name: "ItemCategory",
                table: "GoodDetails");

            migrationBuilder.InsertData(
                table: "SuperAdministrators",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "PhoneNumber", "UserName", "UserType" },
                values: new object[] { new Guid("2837d875-aa14-4f3c-a09a-6c00c840682a"), "SuperAdmin1", "SuperAdmin1", "superadmin1", null, "superAdmin1", null });
        }
    }
}
