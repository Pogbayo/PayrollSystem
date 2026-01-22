using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Application.Interfaces.IService
{
    public interface ISalaryStructureService
    {
        Task<IEnumerable<SalaryStructure>> GetByEmployeeIdAsync(Guid employeeId);
        Task<Guid> AddAsync(SalaryStructure entity);
        Task<decimal> CalculateGrossPayAsync(Guid employeeId);
    }
}
