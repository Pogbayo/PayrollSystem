namespace Payroll.Application.Helpers
{
    public interface IPaymentProcessor
    {
        Task<bool> PayAsync(string accountNumber, decimal amount);
    }
}
