using Microsoft.EntityFrameworkCore.Migrations;

namespace test.Repository.Migrations
{
    public partial class ChangedDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Policies",
                nullable: false,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Policies",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
