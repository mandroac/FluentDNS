using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FNDS.Persistence.Migrations
{
    public partial class SeedUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsSandbox",
                table: "Domains",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("781ac221-b109-453b-a525-95bc9ec87678"), "227731e6-a43d-419c-b643-bcab781f03a6", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("fd55fe70-7497-4f55-980e-0d936d6bee4e"), "104acd3b-948a-4337-8041-894e76366fac", "user", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("781ac221-b109-453b-a525-95bc9ec87678"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fd55fe70-7497-4f55-980e-0d936d6bee4e"));

            migrationBuilder.AlterColumn<bool>(
                name: "IsSandbox",
                table: "Domains",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
