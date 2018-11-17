using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sgs.Attendance.Mvc.Services
{
    public class AttendanceHttpClient : IAttendanceHttpClient
    {
        public Task<HttpClient> GetClient()
        {
            throw new NotImplementedException();
        }
    }
}
