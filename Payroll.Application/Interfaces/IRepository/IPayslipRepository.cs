

namespace Payroll.Application.Interfaces.IRepository
{
    public interface IPayslipRepository
    {
        Task<PayrollRun?> GetByIdAsync(Guid id);
        Task<PayrollRun?> GetByMonthYearAsync(int month, int year);
        Task<IEnumerable<PayrollRun>> GetAllAsync();
        Task<IEnumerable<PayrollRun>> GetByYearAsync(int year);
        Task AddAsync(PayrollRun entity);
        Task DeleteAsync(Guid id);
    }
}
