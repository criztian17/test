using Microsoft.EntityFrameworkCore.Migrations;

namespace test.Repository.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Policies_Clients_ClientId",
                table: "Policies");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicyDetails_Policies_PolicyId",
                table: "PolicyDetails");

            migrationBuilder.AlterColumn<int>(
                name: "PolicyId",
                table: "PolicyDetails",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Policies",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Policies_Clients_ClientId",
                table: "Policies",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyDetails_Policies_PolicyId",
                table: "PolicyDetails",
                column: "PolicyId",
                principalTable: "Policies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Policies_Clients_ClientId",
                table: "Policies");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicyDetails_Policies_PolicyId",
                table: "PolicyDetails");

            migrationBuilder.AlterColumn<int>(
                name: "PolicyId",
                table: "PolicyDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Policies",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Policies_Clients_ClientId",
                table: "Policies",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyDetails_Policies_PolicyId",
                table: "PolicyDetails",
                column: "PolicyId",
                principalTable: "Policies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
