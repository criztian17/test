using Microsoft.EntityFrameworkCore.Migrations;

namespace test.Repository.Migrations
{
    public partial class CoverageRelationShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoverageId",
                table: "PolicyDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PolicyDetails_CoverageId",
                table: "PolicyDetails",
                column: "CoverageId");

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyDetails_Coverages_CoverageId",
                table: "PolicyDetails",
                column: "CoverageId",
                principalTable: "Coverages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PolicyDetails_Coverages_CoverageId",
                table: "PolicyDetails");

            migrationBuilder.DropIndex(
                name: "IX_PolicyDetails_CoverageId",
                table: "PolicyDetails");

            migrationBuilder.DropColumn(
                name: "CoverageId",
                table: "PolicyDetails");
        }
    }
}
