namespace Payroll.Application.Interfaces.Services
{
    public interface ISimpleEmailService
    {
        Task<bool> SendEmailAsync(
                List<string> emailRecipients,
                string subject,
                string body);
    }
}

