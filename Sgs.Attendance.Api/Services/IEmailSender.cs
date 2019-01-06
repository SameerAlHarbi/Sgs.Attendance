using System.Threading.Tasks;

namespace Sgs.Attendance.Api.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);

        Task SendEmailAsync(int employeeId, string subject, string message);
    }
}
