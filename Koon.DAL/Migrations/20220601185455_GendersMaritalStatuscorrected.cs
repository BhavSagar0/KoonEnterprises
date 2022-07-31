using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Koon.DAL.Migrations
{
    public partial class GendersMaritalStatuscorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveApplications",
                table: "LeaveApplications");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "LeaveApplications");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "LeaveApplications");

            migrationBuilder.DropColumn(
                name: "NumberOfDays",
                table: "LeaveApplications");

            migrationBuilder.AddColumn<int>(
                name: "LeaveId",
                table: "LeaveApplications",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "LeaveApplications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LeaveApplications",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveApplications",
                table: "LeaveApplications",
                column: "LeaveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveApplications",
                table: "LeaveApplications");

            migrationBuilder.DropColumn(
                name: "LeaveId",
                table: "LeaveApplications");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "LeaveApplications");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "LeaveApplications");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "LeaveApplications",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "LeaveApplications",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "NumberOfDays",
                table: "LeaveApplications",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveApplications",
                table: "LeaveApplications",
                column: "FirstName");
        }
    }
}
