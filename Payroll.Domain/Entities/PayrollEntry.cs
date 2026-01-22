public class PayrollEntry
{
    public Guid Id { get; set; }

    public Guid PayrollRunId { get; set; }
    public virtual PayrollRun? PayrollRun { get; set; }

    public Guid EmployeeId { get; set; }
    public virtual Employee? Employee { get; set; }

    public decimal GrossPay { get; set; } //moeny gotten from extra hours of work
    public decimal TotalDeductions { get; set; } //like taxes, damages or pension deducted from your gross pay
    public decimal NetPay { get; set; } // how much is left fter all the calculations

    public virtual ICollection<Payslip> Payslips { get; set; } = new List<Payslip>();
}
