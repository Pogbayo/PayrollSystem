using Microsoft.EntityFrameworkCore;
using Payroll.Application.Interfaces.IRepository;
using Payroll.Infrastructure.Data;

namespace Payroll.Infrastructure.Repositories
{
    public class PayrollEntryRepository : IPayrollEntryRepository
    {
        private readonly PayrollDbContext _context;

        public PayrollEntryRepository(PayrollDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(PayrollEntry entity)
        {
            await _context.PayrollEntries.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PayrollEntry>> GetByEmployeeIdAsync(Guid employeeId)
        {
            return await _context.PayrollEntries
                .Where(p => p.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task<PayrollEntry?> GetByIdAsync(Guid id)
        {
            return await _context.PayrollEntries
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
