using Payroll.Application.Interfaces.IRepository;


namespace Payroll.Infrastructure.Repositories
{
    public class PayrollRunRepository : IPayrollRunRepository
    {
        public Task AddAsync(PayrollRun entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PayrollRun>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PayrollRun?> GetByMonthYearAsync(int month, int year)
        {
            throw new NotImplementedException();
        }
    }
}
