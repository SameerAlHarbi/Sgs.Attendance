using Microsoft.EntityFrameworkCore.Migrations;

namespace Sgs.Attendance.DataAccess.Migrations
{
    public partial class ExemptedResoneLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ExemptedResone",
                table: "EmployeesInfo",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ExemptedResone",
                table: "EmployeesInfo",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
