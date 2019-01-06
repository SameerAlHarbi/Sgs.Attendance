using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sgs.Attendance.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentsInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    ManagerAttendanceProof = table.Column<int>(nullable: false),
                    ManagerExempted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentsInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DevicesInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 8, nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    IpAddress = table.Column<string>(maxLength: 20, nullable: false),
                    LocationArabic = table.Column<string>(nullable: false),
                    LocationEnglish = table.Column<string>(nullable: false),
                    Model = table.Column<string>(maxLength: 20, nullable: false),
                    RefrenceNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevicesInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(nullable: false),
                    Exempted = table.Column<bool>(nullable: false),
                    ExemptedDate = table.Column<DateTime>(nullable: true),
                    ExemptedResone = table.Column<string>(maxLength: 100, nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkShiftsCalendars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    AttendanceProof = table.Column<int>(nullable: false),
                    IsVacationCalendar = table.Column<bool>(nullable: false),
                    VacationDescription = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShiftsCalendars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkShiftsSystems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 4, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    AttendanceProof = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShiftsSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesWorkShiftsCalendars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeInfoId = table.Column<int>(nullable: false),
                    WorkShiftsCalendarId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesWorkShiftsCalendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeesWorkShiftsCalendars_EmployeesInfo_EmployeeInfoId",
                        column: x => x.EmployeeInfoId,
                        principalTable: "EmployeesInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeesWorkShiftsCalendars_WorkShiftsCalendars_WorkShiftsCalendarId",
                        column: x => x.WorkShiftsCalendarId,
                        principalTable: "WorkShiftsCalendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkShiftsCalendarsCycles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CycleOrder = table.Column<int>(nullable: false),
                    RepeatCount = table.Column<int>(nullable: false),
                    ShiftStart = table.Column<double>(nullable: true),
                    ShiftEnd = table.Column<double>(nullable: true),
                    IsDayOff = table.Column<bool>(nullable: false),
                    DayOffDescription = table.Column<string>(nullable: true),
                    ShiftStartInRamadan = table.Column<double>(nullable: true),
                    ShiftEndInRamadan = table.Column<double>(nullable: true),
                    IsDayOffInRamadan = table.Column<bool>(nullable: true),
                    DayOffDescriptionInRamadan = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    WorkShiftsCalendarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShiftsCalendarsCycles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkShiftsCalendarsCycles_WorkShiftsCalendars_WorkShiftsCalendarId",
                        column: x => x.WorkShiftsCalendarId,
                        principalTable: "WorkShiftsCalendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesWorkShiftsSystems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeInfoId = table.Column<int>(nullable: false),
                    WorkShiftsSystemId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesWorkShiftsSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeesWorkShiftsSystems_EmployeesInfo_EmployeeInfoId",
                        column: x => x.EmployeeInfoId,
                        principalTable: "EmployeesInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeesWorkShiftsSystems_WorkShiftsSystems_WorkShiftsSystemId",
                        column: x => x.WorkShiftsSystemId,
                        principalTable: "WorkShiftsSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkShiftsSystemsCalendars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WorkShiftsSystemId = table.Column<int>(nullable: false),
                    WorkShiftsCalendarId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShiftsSystemsCalendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkShiftsSystemsCalendars_WorkShiftsCalendars_WorkShiftsCalendarId",
                        column: x => x.WorkShiftsCalendarId,
                        principalTable: "WorkShiftsCalendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkShiftsSystemsCalendars_WorkShiftsSystems_WorkShiftsSystemId",
                        column: x => x.WorkShiftsSystemId,
                        principalTable: "WorkShiftsSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkShiftsSystemsCycles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CycleOrder = table.Column<int>(nullable: false),
                    RepeatCount = table.Column<int>(nullable: false),
                    ShiftStart = table.Column<double>(nullable: true),
                    ShiftEnd = table.Column<double>(nullable: true),
                    IsDayOff = table.Column<bool>(nullable: false),
                    DayOffDescription = table.Column<string>(nullable: true),
                    ShiftStartInRamadan = table.Column<double>(nullable: true),
                    ShiftEndInRamadan = table.Column<double>(nullable: true),
                    IsDayOffInRamadan = table.Column<bool>(nullable: true),
                    DayOffDescriptionInRamadan = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    WorkShiftsSystemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShiftsSystemsCycles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkShiftsSystemsCycles_WorkShiftsSystems_WorkShiftsSystemId",
                        column: x => x.WorkShiftsSystemId,
                        principalTable: "WorkShiftsSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesWorkShiftsCalendars_EmployeeInfoId",
                table: "EmployeesWorkShiftsCalendars",
                column: "EmployeeInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesWorkShiftsCalendars_WorkShiftsCalendarId",
                table: "EmployeesWorkShiftsCalendars",
                column: "WorkShiftsCalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesWorkShiftsSystems_EmployeeInfoId",
                table: "EmployeesWorkShiftsSystems",
                column: "EmployeeInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesWorkShiftsSystems_WorkShiftsSystemId",
                table: "EmployeesWorkShiftsSystems",
                column: "WorkShiftsSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShiftsCalendarsCycles_WorkShiftsCalendarId",
                table: "WorkShiftsCalendarsCycles",
                column: "WorkShiftsCalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShiftsSystemsCalendars_WorkShiftsCalendarId",
                table: "WorkShiftsSystemsCalendars",
                column: "WorkShiftsCalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShiftsSystemsCalendars_WorkShiftsSystemId",
                table: "WorkShiftsSystemsCalendars",
                column: "WorkShiftsSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShiftsSystemsCycles_WorkShiftsSystemId",
                table: "WorkShiftsSystemsCycles",
                column: "WorkShiftsSystemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentsInfo");

            migrationBuilder.DropTable(
                name: "DevicesInfo");

            migrationBuilder.DropTable(
                name: "EmployeesWorkShiftsCalendars");

            migrationBuilder.DropTable(
                name: "EmployeesWorkShiftsSystems");

            migrationBuilder.DropTable(
                name: "WorkShiftsCalendarsCycles");

            migrationBuilder.DropTable(
                name: "WorkShiftsSystemsCalendars");

            migrationBuilder.DropTable(
                name: "WorkShiftsSystemsCycles");

            migrationBuilder.DropTable(
                name: "EmployeesInfo");

            migrationBuilder.DropTable(
                name: "WorkShiftsCalendars");

            migrationBuilder.DropTable(
                name: "WorkShiftsSystems");
        }
    }
}
