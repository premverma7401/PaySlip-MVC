using Microsoft.EntityFrameworkCore.Migrations;

namespace PayMe.Persistence.Migrations
{
    public partial class AddedPaycycletaxcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PayCycle",
                table: "PayInfoEmployees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TaxCode",
                table: "PayInfoEmployees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayCycle",
                table: "PayInfoEmployees");

            migrationBuilder.DropColumn(
                name: "TaxCode",
                table: "PayInfoEmployees");
        }
    }
}
