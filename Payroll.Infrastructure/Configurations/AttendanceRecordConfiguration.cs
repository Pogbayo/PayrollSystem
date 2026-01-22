using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Payroll.Infrastructure.Configurations
{
    public class AttendanceRecordConfiguration : IEntityTypeConfiguration<AttendanceRecord>
    {
        public void Configure(EntityTypeBuilder<AttendanceRecord> builder)
        {
            // Primary key
            builder.HasKey(ar => ar.Id);

            // Properties
            builder.Property(ar => ar.EmployeeId).IsRequired();
            builder.Property(ar => ar.WorkDate).IsRequired();
            builder.Property(ar => ar.HoursWorked).HasColumnType("decimal(5,2)").IsRequired(); 
            builder.Property(ar => ar.OvertimeHours).HasColumnType("decimal(5,2)").IsRequired().HasDefaultValue(0);

            //Relationship: One employe has many AttendanceRecords
            builder.HasOne(ar => ar.Employee)
                .WithMany(e => e.AttendanceRecords)
                .HasForeignKey(ar => ar.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
