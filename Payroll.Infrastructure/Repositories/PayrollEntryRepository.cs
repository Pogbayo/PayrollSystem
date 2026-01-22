using Payroll.Application.Interfaces.IRepository;

namespace Payroll.Infrastructure.Repositories
{
    public class PayrollEntryRepository : IPayrollEntryRepository
    {
        public Task AddAsync(PayrollEntry entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PayrollEntry>> GetByEmployeeIdAsync(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<PayrollEntry?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
