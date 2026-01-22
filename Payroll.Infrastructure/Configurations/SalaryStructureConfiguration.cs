using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Payroll.Infrastructure.Configurations
{
    public class SalaryStructureConfiguration : IEntityTypeConfiguration<SalaryStructure>
    {
        public void Configure(EntityTypeBuilder<SalaryStructure> builder)
        {
            //Primary key
            builder.HasKey(ss => ss.Id);

            // Properties
            builder.Property(ss => ss.EmployeeId).IsRequired();
            builder.Property(ss => ss.BasicSalary).HasColumnType("decimal(18,2)").IsRequired().HasDefaultValue(0);
            builder.Property(ss => ss.HousingAllowance).HasColumnType("decimal(18,2)").IsRequired().HasDefaultValue(0);
            builder.Property(ss => ss.TransportAllowance).HasColumnType("decimal(18,2)").IsRequired().HasDefaultValue(0);
            builder.Property(ss => ss.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");

            //Relationships
            builder.HasOne(ss => ss.Employee)
                   .WithMany(e => e.SalaryStructures)
                   .HasForeignKey(ss => ss.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
