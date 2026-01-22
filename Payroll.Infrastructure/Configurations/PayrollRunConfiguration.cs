using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payroll.Domain.Enums;

namespace Payroll.Infrastructure.Configurations
{
    public class PayrollRunConfiguration : IEntityTypeConfiguration<PayrollRun>
    {
        public void Configure(EntityTypeBuilder<PayrollRun> builder)
        {
            // Primary key
            builder.HasKey(pr => pr.Id);

            // Properties
            builder.Property(pr => pr.Month).IsRequired();
            builder.Property(pr => pr.Year).IsRequired();
            builder.Property(pr => pr.Status).IsRequired().HasDefaultValue(Status.Pending);
            builder.Property(pr => pr.ProcessedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");

            builder.HasIndex(pr => new { pr.Month, pr.Year }).IsUnique();

            // Relationship: One PayrollRun has many PayrollEntries
            builder.HasMany(pr => pr.PayrollEntries)
                   .WithOne(pe => pe.PayrollRun)
                   .HasForeignKey(pe => pe.PayrollRunId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
