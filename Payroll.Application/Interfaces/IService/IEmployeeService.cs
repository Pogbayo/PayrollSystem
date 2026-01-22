namespace Payroll.Application.Interfaces.IService
{
    public interface IEmployeeService
    {
        Task<Employee?> GetByIdAsync(Guid id);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Guid> AddAsync(Employee entity);
    }
}
