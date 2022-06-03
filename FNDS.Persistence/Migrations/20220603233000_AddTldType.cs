using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FNDS.Persistence.Migrations
{
    public partial class AddTldType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "SandboxTLDs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "ProductionTLDs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("781ac221-b109-453b-a525-95bc9ec87678"),
                column: "ConcurrencyStamp",
                value: "b3fd2ceb-b658-4acd-8f32-7ee301cc9221");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fd55fe70-7497-4f55-980e-0d936d6bee4e"),
                column: "ConcurrencyStamp",
                value: "4a9f1745-d710-4418-b4c4-8114bbc30212");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "SandboxTLDs");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ProductionTLDs");

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
    }
}
