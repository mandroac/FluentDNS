using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FNDS.Persistence.Migrations
{
    public partial class AddIsSandboxColumnInDomainsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSandbox",
                table: "Domains",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSandbox",
                table: "Domains");
        }
    }
}
