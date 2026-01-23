using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Payroll.Infrastructure.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //Primary key
            builder.HasKey(e => e.Id);

            //Properties
            //builder.Property(e => e.EmployeeCode)
            //       .HasMaxLength(50)
            //       .IsRequired()
            //       .HasMaxLength(20);

            builder.Property(e => e.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(e => e.Email)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(e => e.LastName)
                   .IsRequired()
                   .HasMaxLength(50);

            //builder.Property(e => e.SalaryType)
            //       .HasConversion<string>()
            //       .IsRequired();

            builder.Property(e => e.BaseSalary)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(e => e.BankAccountNumber)
                   .HasMaxLength(10)
                   .IsRequired(false);

            //builder.Property(e => e.IsActive)
            //       .HasMaxLength(50)
            //       .IsRequired(true);

            builder.Property(e => e.CreatedAt)
                   .IsRequired()
                   .HasDefaultValueSql("GETUTCDATE()");

            //builder.HasIndex(e => e.EmployeeCode).IsUnique();

            //Relationships
            //builder.HasMany(e => e.AttendanceRecords)
            //       .WithOne(ar => ar.Employee)
            //       .HasForeignKey(ar => ar.EmployeeId)
            //       .OnDelete(DeleteBehavior.Restrict);

            //builder.HasMany(e => e.Deductions)
            //       .WithOne(d => d.Employee)
            //       .HasForeignKey(d => d.EmployeeId)
            //       .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.SalaryStructures)
                   .WithOne(ss => ss.Employee)
                   .HasForeignKey(ss => ss.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.PayrollEntries)
                   .WithOne(pe => pe.Employee)
                   .HasForeignKey(pe => pe.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
