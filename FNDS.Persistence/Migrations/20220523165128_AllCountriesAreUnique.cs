using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FNDS.Persistence.Migrations
{
    public partial class AllCountriesAreUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Countries_FullName",
                table: "Countries");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_FullName",
                table: "Countries",
                column: "FullName",
                unique: true)
                .Annotation("SqlServer:Clustered", false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Countries_FullName",
                table: "Countries");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_FullName",
                table: "Countries",
                column: "FullName")
                .Annotation("SqlServer:Clustered", false);
        }
    }
}
