using Payroll.Application.Interfaces.IRepository;
using Payroll.Application.Interfaces.IService;

namespace Payroll.Infrastructure.Repositories
{
    public class SalaryStructureRepository : ISalaryStructureRepository
    {
        public Task AddAsync(SalaryStructure entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SalaryStructure>> GetByEmployeeIdAsync(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<SalaryStructure?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
