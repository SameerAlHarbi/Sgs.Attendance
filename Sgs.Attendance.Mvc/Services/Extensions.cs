using Sgs.Attendance.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sgs.Attendance.Mvc.Services
{
    public static class Extensions
    {
        public static string GetName(this AttendanceProof attendanceProof)
        {
            switch (attendanceProof)
            {
                case AttendanceProof.RequiredInOut:
                    return "حضور و انصراف";
                case AttendanceProof.RequiredIn:
                    return "حضور فقط";
                default:
                    return "معفي";
            }
        }
    }
}
