using Payroll.Application.Interfaces.IService;

namespace Payroll.Application.Services
{

    public class PaymentService : IPaymentService
    {
        public async Task<bool> PayAsync(string accountNumber, decimal amount)
        {
            await Task.Delay(100); 

            var random = new Random();
            bool success = random.Next(0, 10) > 1;

            return success;
        }
    }
}
