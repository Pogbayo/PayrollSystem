
namespace Payroll.Application.Interfaces.IRepository
{
    public interface IDeductionRepository
    {
        Task<Deduction?> GetByIdAsync(Guid id);
        Task<IEnumerable<Deduction>> GetByEmployeeIdAsync(Guid employeeId);
        Task AddAsync(Deduction entity);
    }
}
