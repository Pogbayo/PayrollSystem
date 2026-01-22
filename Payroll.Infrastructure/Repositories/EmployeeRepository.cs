using Payroll.Application.Interfaces.IRepository;

namespace Payroll.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Task AddAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employee?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
