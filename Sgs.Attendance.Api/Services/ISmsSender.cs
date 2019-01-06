using System.Threading.Tasks;

namespace Sgs.Attendance.Api.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string phoneNumber, string message);
    }
}