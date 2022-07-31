using Microsoft.EntityFrameworkCore.Migrations;

namespace Koon.DAL.Migrations
{
    public partial class DeptTableCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Departments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Departments",
                nullable: false,
                defaultValue: 0);
        }
    }
}
