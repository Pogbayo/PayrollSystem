

namespace Payroll.Application.Interfaces.IService
{
    public interface IDeductionService
    {
        Task<IEnumerable<Deduction>> GetByEmployeeIdAsync(Guid employeeId);
        Task<Guid> AddAsync(Deduction entity);
        Task<decimal> CalculateTotalDeductionsAsync(Guid employeeId);
    }
}
