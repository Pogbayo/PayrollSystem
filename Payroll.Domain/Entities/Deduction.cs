public class Deduction
{
    public Guid Id { get; set; }

    public Guid EmployeeId { get; set; }
    public required Employee Employee { get; set; }

    public decimal Tax { get; set; }
    public decimal Pension { get; set; }
    public decimal Loan { get; set; }

    public DateTime CreatedAt { get; set; }
}
