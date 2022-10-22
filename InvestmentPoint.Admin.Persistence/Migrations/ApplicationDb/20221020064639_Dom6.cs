using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestmentPoint.Admin.Persistence.Migrations.ApplicationDb
{
    public partial class Dom6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomersEMIs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfInvest = table.Column<int>(type: "int", nullable: false),
                    EMIAmc = table.Column<int>(type: "int", nullable: false),
                    BalanceAmc = table.Column<int>(type: "int", nullable: false),
                    DateOfEMI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersEMIs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersEMIs");
        }
    }
}
