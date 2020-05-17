using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop4U.Enrollment.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SuperAdministrators",
                keyColumn: "Id",
                keyValue: new Guid("2379f30a-5868-4ffa-b68c-c4473c166afa"));

            migrationBuilder.AddColumn<string>(
                name: "ItemCategory",
                table: "Goods",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CostPrice",
                table: "GoodDetails",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Auths",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auths", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SuperAdministrators",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "PhoneNumber", "UserName", "UserType" },
                values: new object[] { new Guid("2837d875-aa14-4f3c-a09a-6c00c840682a"), "SuperAdmin1", "SuperAdmin1", "superadmin1", null, "superAdmin1", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auths");

            migrationBuilder.DeleteData(
                table: "SuperAdministrators",
                keyColumn: "Id",
                keyValue: new Guid("2837d875-aa14-4f3c-a09a-6c00c840682a"));

            migrationBuilder.DropColumn(
                name: "ItemCategory",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "CostPrice",
                table: "GoodDetails");

            migrationBuilder.InsertData(
                table: "SuperAdministrators",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "PhoneNumber", "UserName", "UserType" },
                values: new object[] { new Guid("2379f30a-5868-4ffa-b68c-c4473c166afa"), "SuperAdmin1", "SuperAdmin1", "superadmin1", null, "superAdmin1", null });
        }
    }
}
