using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Payroll.Infrastructure.Configurations
{
    public class DeductionConfiguration : IEntityTypeConfiguration<Deduction>
    {
        public void Configure(EntityTypeBuilder<Deduction> builder)
        {
            // Primary key
            builder.HasKey(d => d.Id);

            // Properties
            builder.Property(d => d.EmployeeId).IsRequired();
            builder.Property(d => d.Tax).HasColumnType("decimal(18,2)").IsRequired().HasDefaultValue(0);
            builder.Property(d => d.Pension).HasColumnType("decimal(18,2)").IsRequired().HasDefaultValue(0);
            builder.Property(d => d.Loan).HasColumnType("decimal(18,2)").IsRequired().HasDefaultValue(0);
            builder.Property(d => d.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()"); // Auto-now

            // Relationship: One Employee has many Deductions
            builder.HasOne(d => d.Employee)
                   .WithMany(e => e.Deductions) 
                   .HasForeignKey(d => d.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
