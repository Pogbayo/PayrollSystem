namespace Payroll.Application.Dtos.PayrollEntryDto
{
    public class CreatePayrollEntryDto
    {
        public Guid EmployeeId { get; set; }
        public decimal GrossPay { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
