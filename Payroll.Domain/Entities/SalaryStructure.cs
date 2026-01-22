public class SalaryStructure
{
    public Guid Id { get; set; }

    public Guid EmployeeId { get; set; }
    public required Employee Employee { get; set; }

    public decimal BasicSalary { get; set; }
    public decimal HousingAllowance { get; set; }
    public decimal TransportAllowance { get; set; }
    public DateTime CreatedAt { get; set; }
}
