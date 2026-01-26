namespace Payroll.Application.Interfaces.IService
{
    public interface IPayrollProcessingService
    {
        Task ProcessPayrollAsync(int month, int year);
    }
}
