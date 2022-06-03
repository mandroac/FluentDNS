using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FNDS.Persistence.Migrations
{
    public partial class AddPricingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductionDomainPricing",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    DurationType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserPrice = table.Column<double>(type: "float", nullable: false),
                    RegularPrice = table.Column<double>(type: "float", nullable: false),
                    AdditionalCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionDomainPricing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SandboxDomainPricing",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    DurationType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserPrice = table.Column<double>(type: "float", nullable: false),
                    RegularPrice = table.Column<double>(type: "float", nullable: false),
                    AdditionalCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SandboxDomainPricing", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("781ac221-b109-453b-a525-95bc9ec87678"),
                column: "ConcurrencyStamp",
                value: "ddcadec1-d78e-4628-bdfb-e7c9449092a0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fd55fe70-7497-4f55-980e-0d936d6bee4e"),
                column: "ConcurrencyStamp",
                value: "f81106a7-0541-4e3e-8c98-e13cade7eff0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionDomainPricing");

            migrationBuilder.DropTable(
                name: "SandboxDomainPricing");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("781ac221-b109-453b-a525-95bc9ec87678"),
                column: "ConcurrencyStamp",
                value: "227731e6-a43d-419c-b643-bcab781f03a6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fd55fe70-7497-4f55-980e-0d936d6bee4e"),
                column: "ConcurrencyStamp",
                value: "104acd3b-948a-4337-8041-894e76366fac");
        }
    }
}