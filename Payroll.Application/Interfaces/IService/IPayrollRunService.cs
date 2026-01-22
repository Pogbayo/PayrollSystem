

namespace Payroll.Application.Interfaces.IService
{
    public interface IPayrollRunService
    {
        Task<PayrollRun?> GetByMonthYearAsync(int month, int year);
        Task<IEnumerable<PayrollRun>> GetAllAsync();
        Task<Guid> AddAsync(PayrollRun entity);
        Task ProcessRunAsync(Guid payrollRunId);
    }
}
