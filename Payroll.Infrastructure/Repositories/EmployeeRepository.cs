using Microsoft.EntityFrameworkCore;
using Payroll.Application.Interfaces.IRepository;
using Payroll.Infrastructure.Data;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly PayrollDbContext _context;

    public EmployeeRepository(PayrollDbContext context)
    {
        _context = context;
    }

    public async Task<Employee?> GetByIdAsync(Guid id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task AddAsync(Employee entity)
    {
        await _context.Employees.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
}