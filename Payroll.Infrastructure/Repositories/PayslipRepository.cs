using Payroll.Application.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Infrastructure.Repositories
{
    public class PayslipRepository : IPayslipRepository
    {
        public Task AddAsync(PayrollRun entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PayrollRun>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PayrollRun?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PayrollRun?> GetByMonthYearAsync(int month, int year)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PayrollRun>> GetByYearAsync(int year)
        {
            throw new NotImplementedException();
        }
    }
}
