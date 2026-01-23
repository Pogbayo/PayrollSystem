

namespace Payroll.Application.Interfaces.IRepository
{
    public interface IPayslipRepository
    {
        Task<Payslip?> GetByIdAsync(Guid id);
        Task<Payslip?> GetByMonthYearAsync(int month, int year);
        Task<IEnumerable<Payslip>> GetAllAsync();
        Task<IEnumerable<Payslip>> GetByYearAsync(int year);
        Task AddAsync(Payslip entity);
    }
}
