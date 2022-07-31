using Microsoft.EntityFrameworkCore.Migrations;

namespace Koon.DAL.Migrations
{
    public partial class DeptAddedtoEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "EmployeeDetails",
                nullable: false,
                defaultValue: 1);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDetails_Departments_DepartmentId",
                table: "EmployeeDetails");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDetails_DepartmentId",
                table: "EmployeeDetails");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "EmployeeDetails");
        }
    }
}
