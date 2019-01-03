using Microsoft.EntityFrameworkCore;
using Sgs.Attendance.Model;

namespace Sgs.Attendance.DataAccess
{
    public class AttendanceDb : DbContext
    {
        public AttendanceDb(DbContextOptions<AttendanceDb> options) : base(options)
        {
        }

        public DbSet<WorkShiftsSystem> WorkShiftsSystems { get; set; }

        public DbSet<DepartmentInfo> DepartmentsInfo { get; set; }

        public DbSet<EmployeeInfo> EmployeesInfo { get; set; }

        public DbSet<EmployeeWorkShiftsSystem> EmployeesWorkShiftsSystems { get; set; }

    }
}
