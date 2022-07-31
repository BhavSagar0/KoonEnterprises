using Microsoft.EntityFrameworkCore.Migrations;

namespace Koon.DAL.Migrations
{
    public partial class DeptAddedtoEmployeeInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDetails_Departments_DepartmentId",
                table: "EmployeeDetails");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDetails_DepartmentId",
                table: "EmployeeDetails");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "EmployeeDetails",
                newName: "Department");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Department",
                table: "EmployeeDetails",
                newName: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDetails_DepartmentId",
                table: "EmployeeDetails",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDetails_Departments_DepartmentId",
                table: "EmployeeDetails",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
