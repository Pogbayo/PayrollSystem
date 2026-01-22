using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Payroll.Infrastructure.Configurations
{
    public class PayrollEntryConfiguration : IEntityTypeConfiguration<PayrollEntry>
    {
        public void Configure(EntityTypeBuilder<PayrollEntry> builder)
        {
            //Primary key
            builder.HasKey(pe => pe.Id);

            //Properties
            builder.Property(pe => pe.EmployeeId).IsRequired();
            builder.Property(pe => pe.PayrollRunId).IsRequired();
            builder.Property(pe => pe.GrossPay).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(pe => pe.TotalDeductions).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(pe => pe.NetPay).HasColumnType("decimal(18,2)").IsRequired();

            //Relationships
            builder.HasOne(pe => pe.PayrollRun)
                   .WithMany(pr => pr.PayrollEntries)
                   .HasForeignKey(pe => pe.PayrollRunId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pe => pe.Employee)
                   .WithMany(e => e.PayrollEntries)
                   .HasForeignKey(pe => pe.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
