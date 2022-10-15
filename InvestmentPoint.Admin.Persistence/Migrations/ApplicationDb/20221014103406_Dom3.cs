using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestmentPoint.Admin.Persistence.Migrations.ApplicationDb
{
    public partial class Dom3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EMIDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EMIDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Customers");
        }
    }
}
