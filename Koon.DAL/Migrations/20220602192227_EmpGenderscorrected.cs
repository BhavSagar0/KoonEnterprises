using Microsoft.EntityFrameworkCore.Migrations;

namespace Koon.DAL.Migrations
{
    public partial class EmpGenderscorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepartmentNamw",
                table: "Departments",
                newName: "DepartmentName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepartmentName",
                table: "Departments",
                newName: "DepartmentNamw");
        }
    }
}
