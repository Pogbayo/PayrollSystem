namespace Payroll.Application.Interfaces.IRepository
{
    public interface ISalaryStructureRepository
    {
        Task<SalaryStructure?> GetByIdAsync(Guid id);
        Task<IEnumerable<SalaryStructure>> GetByEmployeeIdAsync(Guid employeeId);
        Task AddAsync(SalaryStructure entity);
    }
}
