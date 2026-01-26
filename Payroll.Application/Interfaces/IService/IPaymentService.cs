namespace Payroll.Application.Interfaces.IService
{
    public interface IPaymentService
    {
        Task<bool> PayAsync(string accountNumber, decimal amount);
        //Task ProcessPayrollAsync(int month, int year);
    }
}
