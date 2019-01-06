using System.Threading.Tasks;

namespace Sgs.Attendance.Api.Services
{
    public class SmsSender : ISmsSender
    {
        public Task SendSmsAsync(string phoneNumber, string message)
        {
            return Task.CompletedTask;
        }
    }
}