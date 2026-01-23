using Microsoft.EntityFrameworkCore;
using Payroll.Application.Interfaces.IRepository;
using Payroll.Infrastructure.Data;

namespace Payroll.Infrastructure.Repositories
{
    public class PayslipRepository : IPayslipRepository
    {
        private readonly PayrollDbContext _context;

        public PayslipRepository(PayrollDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Payslip entity)
        {
            await _context.Payslips.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Payslip>> GetAllAsync()
        {
            return await _context.Payslips
                .Include(p => p.Employee)
                .Include(p => p.PayrollEntry)
                .ToListAsync();
        }

        public async Task<Payslip?> GetByIdAsync(Guid id)
        {
            return await _context.Payslips
                .Include(p => p.Employee)
                .Include(p => p.PayrollEntry)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Payslip?> GetByMonthYearAsync(int month, int year)
        {
            return await _context.Payslips
                .Include(p => p.Employee)
                .Include(p => p.PayrollEntry)
                .ThenInclude(pe => pe!.PayrollRun)
                .FirstOrDefaultAsync(p =>
                    p.PayrollEntry!.PayrollRun!.Month == month &&
                    p.PayrollEntry.PayrollRun.Year == year
                );
        }

        public async Task<IEnumerable<Payslip>> GetByYearAsync(int year)
        {
            return await _context.Payslips
                .Include(p => p.Employee)
                .Include(p => p.PayrollEntry)
                .ThenInclude(pe => pe!.PayrollRun)
                .Where(p => p.PayrollEntry!.PayrollRun!.Year == year)
                .ToListAsync();
        }
    }
}
