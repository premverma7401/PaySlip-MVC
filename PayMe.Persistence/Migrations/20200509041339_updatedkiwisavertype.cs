using Microsoft.EntityFrameworkCore.Migrations;

namespace PayMe.Persistence.Migrations
{
    public partial class updatedkiwisavertype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NIC",
                table: "PaymentRecords");

            migrationBuilder.AddColumn<decimal>(
                name: "KiwiSaver",
                table: "PaymentRecords",
                type: "money",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KiwiSaver",
                table: "PaymentRecords");

            migrationBuilder.AddColumn<decimal>(
                name: "NIC",
                table: "PaymentRecords",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
