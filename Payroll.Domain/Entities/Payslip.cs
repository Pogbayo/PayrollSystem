public class Payslip
{
    public Guid Id { get; set; }

    public Guid PayrollEntryId { get; set; }
    public PayrollEntry? PayrollEntry { get; set; }

    public DateTime IssuedDate { get; set; }
    public required Guid EmployeeId { get; set; }
    public Employee? Employee { get; set; }
}