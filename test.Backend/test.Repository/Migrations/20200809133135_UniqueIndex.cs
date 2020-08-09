using Microsoft.EntityFrameworkCore.Migrations;

namespace test.Repository.Migrations
{
    public partial class UniqueIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Coverages_Description",
                table: "Coverages");

            migrationBuilder.DropIndex(
                name: "IX_Clients_Identification",
                table: "Clients");

            migrationBuilder.CreateIndex(
                name: "IX_Coverages_Description",
                table: "Coverages",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Identification",
                table: "Clients",
                column: "Identification",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Coverages_Description",
                table: "Coverages");

            migrationBuilder.DropIndex(
                name: "IX_Clients_Identification",
                table: "Clients");

            migrationBuilder.CreateIndex(
                name: "IX_Coverages_Description",
                table: "Coverages",
                column: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Identification",
                table: "Clients",
                column: "Identification");
        }
    }
}
