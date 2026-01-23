namespace Payroll.Application.Interfaces.IRepository
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetByIdAsync(Guid id);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task AddAsync(Employee entity);
    }
}
