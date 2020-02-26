using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop4U.Enrollment.Migrations
{
    public partial class SeedEnrollmentCloudDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SuperAdministrators",
                keyColumn: "Id",
                keyValue: new Guid("73dee47b-9c02-4d5f-b0f1-2c2056efb1e5"));

            migrationBuilder.InsertData(
                table: "SuperAdministrators",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "PhoneNumber", "UserName", "UserType" },
                values: new object[] { new Guid("ee19a666-f615-475b-8d6d-bbec211c376a"), "SuperAdmin1", "SuperAdmin1", "superadmin1", null, "superAdmin1", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SuperAdministrators",
                keyColumn: "Id",
                keyValue: new Guid("ee19a666-f615-475b-8d6d-bbec211c376a"));

            migrationBuilder.InsertData(
                table: "SuperAdministrators",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "PhoneNumber", "UserName", "UserType" },
                values: new object[] { new Guid("73dee47b-9c02-4d5f-b0f1-2c2056efb1e5"), "SuperAdmin1", "SuperAdmin1", "superadmin1", null, "superAdmin1", null });
        }
    }
}
