public class PayrollEntry
{
    public Guid Id { get; set; }

    public Guid PayrollRunId { get; set; }
    public PayrollRun? PayrollRun { get; set; }

    public Guid EmployeeId { get; set; }
    public Employee? Employee { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal GrossPay { get; set; } //money gotten from extra hours of work

    //public decimal TotalDeductions { get; set; } //like taxes, damages or pension deducted from your gross pay
    //public decimal NetPay { get; set; } // how much is left all the calculations

    public ICollection<Payslip> Payslips { get; set; } = new List<Payslip>();
}
