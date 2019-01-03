using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sgs.Attendance.DataAccess.Migrations
{
    public partial class EmployeesInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeesInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(nullable: false),
                    Exempted = table.Column<bool>(nullable: false),
                    ExemptedDate = table.Column<DateTime>(nullable: false),
                    ExemptedResone = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesWorkShiftsSystems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(nullable: false),
                    WorkShiftsSystemId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesWorkShiftsSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeesWorkShiftsSystems_WorkShiftsSystems_WorkShiftsSystemId",
                        column: x => x.WorkShiftsSystemId,
                        principalTable: "WorkShiftsSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesWorkShiftsSystems_WorkShiftsSystemId",
                table: "EmployeesWorkShiftsSystems",
                column: "WorkShiftsSystemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesInfo");

            migrationBuilder.DropTable(
                name: "EmployeesWorkShiftsSystems");
        }
    }
}
