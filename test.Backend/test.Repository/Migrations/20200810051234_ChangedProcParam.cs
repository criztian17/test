using Microsoft.EntityFrameworkCore.Migrations;

namespace test.Repository.Migrations
{
    public partial class ChangedProcParam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(Helpers.Resources.Resource.CreateProcPolicy);
            migrationBuilder.Sql(Helpers.Resources.Resource.CreateProcPolicyDetail);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(Helpers.Resources.Resource.DropProcPolicy);
            migrationBuilder.Sql(Helpers.Resources.Resource.DropProcPolicyDetail);
        }
    }
}
