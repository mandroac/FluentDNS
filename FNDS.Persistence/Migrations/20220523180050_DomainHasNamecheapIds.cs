using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FNDS.Persistence.Migrations
{
    public partial class DomainHasNamecheapIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NamecheapId",
                table: "Domains",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NamecheapOrderId",
                table: "Domains",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NamecheapTransactionId",
                table: "Domains",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Domains_NamecheapId",
                table: "Domains",
                column: "NamecheapId",
                unique: true)
                .Annotation("SqlServer:Clustered", false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Domains_NamecheapId",
                table: "Domains");

            migrationBuilder.DropColumn(
                name: "NamecheapId",
                table: "Domains");

            migrationBuilder.DropColumn(
                name: "NamecheapOrderId",
                table: "Domains");

            migrationBuilder.DropColumn(
                name: "NamecheapTransactionId",
                table: "Domains");
        }
    }
}
