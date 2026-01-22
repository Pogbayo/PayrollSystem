using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Application.Interfaces.IService
{
    public interface IPayslipService
    {
        Task<Payslip?> GetByIdAsync(Guid id);
        Task<IEnumerable<Payslip>> GetAllAsync();
        Task<IEnumerable<Payslip>> GetByEmployeeIdAsync(Guid employeeId);
        Task<Guid> AddAsync(Payslip entity);
    }
}
