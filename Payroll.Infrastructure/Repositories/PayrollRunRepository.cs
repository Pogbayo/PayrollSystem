using Microsoft.EntityFrameworkCore;
using Payroll.Application.Interfaces.IRepository;
using Payroll.Infrastructure.Data;

namespace Payroll.Infrastructure.Repositories
{
    public class PayrollRunRepository : IPayrollRunRepository
    {
        private readonly PayrollDbContext _context;

        public PayrollRunRepository(PayrollDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(PayrollRun entity)
        {
            await _context.PayrollRuns.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PayrollRun>> GetAllAsync()
        {
            return await _context.PayrollRuns
                .Include(pr => pr.PayrollEntries)
                .OrderByDescending(pr => pr.Year)
                .ThenByDescending(pr => pr.Month)
                .ToListAsync();
        }

        public async Task<PayrollRun?> GetByMonthYearAsync(int month, int year)
        {
            return await _context.PayrollRuns
                .Include(pr => pr.PayrollEntries)
                .FirstOrDefaultAsync(pr => pr.Month == month && pr.Year == year);
        }
    }
}
