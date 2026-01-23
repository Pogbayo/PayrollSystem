using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Application.Interfaces.IService
{
    public interface IPayrollEntryService
    {
        Task<PayrollEntry?> GetByIdAsync(Guid id);
        Task<IEnumerable<PayrollEntry>> GetByEmployeeIdAsync(Guid employeeId);
        Task<Guid> AddAsync(PayrollEntry entity);
        Task<decimal> CalculateNetPayAsync(Guid employeeId); 
        Task<bool> ProcessAutopaymentAsync(Guid payrollEntryId);
    }
}
