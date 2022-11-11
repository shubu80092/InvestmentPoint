using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestmentPoint.Admin.Persistence.Migrations.ApplicationDb
{
    public partial class Dom8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Advance",
                table: "CustomersEMIs");

            migrationBuilder.DropColumn(
                name: "BalanceAmc",
                table: "CustomersEMIs");

            migrationBuilder.AddColumn<double>(
                name: "Advance",
                table: "Customers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BalanceAmc",
                table: "Customers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalDepositeAmount",
                table: "Customers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Advance",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BalanceAmc",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TotalDepositeAmount",
                table: "Customers");

            migrationBuilder.AddColumn<double>(
                name: "Advance",
                table: "CustomersEMIs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BalanceAmc",
                table: "CustomersEMIs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
