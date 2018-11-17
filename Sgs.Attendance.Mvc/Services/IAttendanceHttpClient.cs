using System.Net.Http;
using System.Threading.Tasks;

namespace Sgs.Attendance.Mvc.Services
{
    public interface IAttendanceHttpClient
    {
        Task<HttpClient> GetClient();
    }
}
