using Microsoft.EntityFrameworkCore;
using Sgs.Attendance.Model;

namespace Sgs.Attendance.DataAccess
{
    public class AttendanceDb : DbContext
    {
        public AttendanceDb(DbContextOptions<AttendanceDb> options) : base(options)
        {
        }

        DbSet<WorkShiftsSystem> WorkShiftsSystems { get; set; }
    }
}
