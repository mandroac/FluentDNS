using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FNDS.Persistence.Migrations
{
    public partial class AddTldTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductionTLDs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NonRealTime = table.Column<bool>(type: "bit", nullable: false),
                    MinRegisterYears = table.Column<int>(type: "int", nullable: false),
                    MaxRegisterYears = table.Column<int>(type: "int", nullable: false),
                    MinRenewYears = table.Column<int>(type: "int", nullable: false),
                    MaxRenewYears = table.Column<int>(type: "int", nullable: false),
                    MinTransferYears = table.Column<int>(type: "int", nullable: false),
                    MaxTransferYears = table.Column<int>(type: "int", nullable: false),
                    IsApiRegisterable = table.Column<bool>(type: "bit", nullable: false),
                    IsApiRenewable = table.Column<bool>(type: "bit", nullable: false),
                    IsApiTransferable = table.Column<bool>(type: "bit", nullable: false),
                    IsEppRequired = table.Column<bool>(type: "bit", nullable: false),
                    IsDisableModContact = table.Column<bool>(type: "bit", nullable: false),
                    IsDisableWGAllot = table.Column<bool>(type: "bit", nullable: false),
                    IsIncludeInExtendedSearchOnly = table.Column<bool>(type: "bit", nullable: false),
                    SequenceNumber = table.Column<int>(type: "int", nullable: false),
                    IsSupportsIDN = table.Column<bool>(type: "bit", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionTLDs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SandboxTLDs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NonRealTime = table.Column<bool>(type: "bit", nullable: false),
                    MinRegisterYears = table.Column<int>(type: "int", nullable: false),
                    MaxRegisterYears = table.Column<int>(type: "int", nullable: false),
                    MinRenewYears = table.Column<int>(type: "int", nullable: false),
                    MaxRenewYears = table.Column<int>(type: "int", nullable: false),
                    MinTransferYears = table.Column<int>(type: "int", nullable: false),
                    MaxTransferYears = table.Column<int>(type: "int", nullable: false),
                    IsApiRegisterable = table.Column<bool>(type: "bit", nullable: false),
                    IsApiRenewable = table.Column<bool>(type: "bit", nullable: false),
                    IsApiTransferable = table.Column<bool>(type: "bit", nullable: false),
                    IsEppRequired = table.Column<bool>(type: "bit", nullable: false),
                    IsDisableModContact = table.Column<bool>(type: "bit", nullable: false),
                    IsDisableWGAllot = table.Column<bool>(type: "bit", nullable: false),
                    IsIncludeInExtendedSearchOnly = table.Column<bool>(type: "bit", nullable: false),
                    SequenceNumber = table.Column<int>(type: "int", nullable: false),
                    IsSupportsIDN = table.Column<bool>(type: "bit", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SandboxTLDs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("781ac221-b109-453b-a525-95bc9ec87678"),
                column: "ConcurrencyStamp",
                value: "cd29fe3c-0292-4c0b-a620-1b12e17100a4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fd55fe70-7497-4f55-980e-0d936d6bee4e"),
                column: "ConcurrencyStamp",
                value: "13f549a6-a363-486e-a287-2f1bd3154037");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionTLDs");

            migrationBuilder.DropTable(
                name: "SandboxTLDs");

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
    }
}
