using Microsoft.EntityFrameworkCore;
using Sgs.Attendance.Model;

namespace Sgs.Attendance.DataAccess
{
    public class AttendanceDb : DbContext
    {
        public AttendanceDb(DbContextOptions<AttendanceDb> options) : base(options)
        {
        }

        public DbSet<DeviceInfo> DevicesInfo { get; set; }

        public DbSet<DepartmentInfo> DepartmentsInfo { get; set; }

        public DbSet<WorkShiftsSystem> WorkShiftsSystems { get; set; }

        public DbSet<EmployeeInfo> EmployeesInfo { get; set; }

        public DbSet<EmployeeWorkShiftsSystem> EmployeesWorkShiftsSystems { get; set; }

        public DbSet<WorkShiftsCalendar> WorkShiftsCalendars { get; set; }

        public DbSet<EmployeeWorkShiftsCalendar> EmployeesWorkShiftsCalendars { get; set; }

        public DbSet<WorkShiftsSystemCalendar> WorkShiftsSystemsCalendars { get; set; }

        public DbSet<WorkShiftsCalendarCycle> WorkShiftsCalendarsCycles { get; set; }

        public DbSet<WorkShiftsSystemCycle> WorkShiftsSystemsCycles { get; set; }
    }
}
