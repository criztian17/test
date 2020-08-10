using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace test.Repository.Migrations
{
    public partial class DecimalColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(Helpers.Resources.Resource.CreateProcPolicy);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Policies",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.CreateTable(
                name: "ResultEntityHelpers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ErrorMessage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultEntityHelpers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(Helpers.Resources.Resource.DropProcPolicy);

            migrationBuilder.DropTable(
                name: "ResultEntityHelpers");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Policies",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");
        }
    }
}
