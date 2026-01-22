using Microsoft.EntityFrameworkCore;

namespace Payroll.Infrastructure.Data
{
    public class PayrollDbContext : DbContext
    {
        public PayrollDbContext(DbContextOptions<PayrollDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<SalaryStructure> SalaryStructures { get; set; }
        public DbSet<Deduction> Deductions { get; set; }
        public DbSet<AttendanceRecord> AttendanceRecords { get; set; }
        public DbSet<PayrollRun> PayrollRuns { get; set; }
        public DbSet<PayrollEntry> PayrollEntries { get; set; }
        public DbSet<Payslip> Payslips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PayrollDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
