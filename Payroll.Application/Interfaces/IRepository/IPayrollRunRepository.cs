using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Application.Interfaces.IRepository
{
    public interface IPayrollRunRepository
    {
        Task<PayrollRun?> GetByMonthYearAsync(int month, int year);
        Task<IEnumerable<PayrollRun>> GetAllAsync();
        Task AddAsync(PayrollRun entity);
    }
}
