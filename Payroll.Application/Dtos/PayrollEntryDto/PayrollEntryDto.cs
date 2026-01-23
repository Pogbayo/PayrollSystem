namespace Payroll.Application.Dtos.PayrollEntryDto
{
    public class PayrollEntryDto
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public decimal GrossPay { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
