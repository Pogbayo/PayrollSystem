using Microsoft.EntityFrameworkCore;
using Payroll.Application.Interfaces.IRepository;
using Payroll.Infrastructure.Data;

namespace Payroll.Infrastructure.Repositories
{
    public class SalaryStructureRepository : ISalaryStructureRepository
    {
        private readonly PayrollDbContext _context;

        public SalaryStructureRepository(PayrollDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(SalaryStructure entity)
        {
            await _context.SalaryStructures.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SalaryStructure>> GetByEmployeeIdAsync(Guid employeeId)
        {
            return await _context.SalaryStructures
                .Where(s => s.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task<SalaryStructure?> GetByIdAsync(Guid id)
        {
            return await _context.SalaryStructures
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
