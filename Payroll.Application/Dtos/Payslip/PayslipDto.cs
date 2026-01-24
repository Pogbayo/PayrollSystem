namespace Payroll.Application.Dtos.PayslipDto
{
    public class PayslipDto
    {
        public Guid Id { get; set; }
        public Guid PayrollEntryId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime IssuedDate { get; set; }

        public string? EmployeeName { get; set; }
        public decimal? Grosspay { get; set; } 
        public int? Month { get; set; } 
        public int? Year { get; set; }  
    }
}
