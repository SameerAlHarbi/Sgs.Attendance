using Microsoft.Extensions.Configuration;

namespace Sgs.Attendance.Mvc.Services
{
    public class AppInfo : IAppInfo
    {
        private IConfiguration _configuration;

        public AppInfo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetAppName()
        {
            return _configuration["AppName"];
        }
    }
}
