using Payroll.Domain.Enums;

public class PayrollRun
{
    public Guid Id { get; set; }

    public int Month { get; set; }
    public int Year { get; set; }

    public Status Status { get; set; } 

    public DateTime ProcessedAt { get; set; }
    public ICollection<PayrollEntry> PayrollEntries { get; set; } = new HashSet<PayrollEntry>();
}
