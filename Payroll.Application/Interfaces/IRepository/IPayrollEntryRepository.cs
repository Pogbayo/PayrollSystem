

namespace Payroll.Application.Interfaces.IRepository
{
    public interface IPayrollEntryRepository
    {
        Task<PayrollEntry?> GetByIdAsync(Guid id);
        Task<IEnumerable<PayrollEntry>> GetByEmployeeIdAsync(Guid employeeId);
        Task AddAsync(PayrollEntry entity);
    }
}
