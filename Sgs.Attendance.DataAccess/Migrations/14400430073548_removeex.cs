using Microsoft.EntityFrameworkCore.Migrations;

namespace Sgs.Attendance.DataAccess.Migrations
{
    public partial class removeex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerExempted",
                table: "DepartmentsInfo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ManagerExempted",
                table: "DepartmentsInfo",
                nullable: false,
                defaultValue: false);
        }
    }
}
