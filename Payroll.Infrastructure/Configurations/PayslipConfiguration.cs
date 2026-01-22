using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Payroll.Infrastructure.Configurations
{
    public class PayslipConfiguration : IEntityTypeConfiguration<Payslip>
    {
        public void Configure(EntityTypeBuilder<Payslip> builder)
        {
            // Primary key
            builder.HasKey(ps => ps.Id);

            // Properties
            builder.Property(ps => ps.PayrollEntryId).IsRequired();
            builder.Property(ps => ps.EmployeeId).IsRequired(); 
            builder.Property(ps => ps.IssuedDate).IsRequired().HasDefaultValueSql("GETUTCDATE()");

            //Relationships
            builder.HasOne(ps => ps.PayrollEntry)
                   .WithMany(pe => pe.Payslips) 
                   .HasForeignKey(ps => ps.PayrollEntryId)
                   .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(ps => ps.Employee)
                   .WithMany(e => e.Payslips) 
                   .HasForeignKey(ps => ps.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
