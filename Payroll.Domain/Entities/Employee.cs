using Payroll.Domain.Enums;

public class Employee
{
    public Guid Id { get; set; }
    public string? EmployeeCode { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Department { get; set; }
    public SalaryType SalaryType { get; set; } 
    public decimal BaseSalary { get; set; }
    public string? BankAccountNumber { get; set; }
    public bool IsActive { get; set; } = false;
    public DateTime CreatedAt { get; set; }
    public virtual ICollection<Payslip> Payslips { get; set; } = new List<Payslip>();
    public virtual ICollection<SalaryStructure> SalaryStructures { get; set; } = new List<SalaryStructure>();
    //public virtual ICollection<Deduction> Deductions { get; set; } = new List<Deduction>();
    //public virtual ICollection<AttendanceRecord> AttendanceRecords { get; set; } = new List<AttendanceRecord>();
    public virtual ICollection<PayrollEntry> PayrollEntries { get; set; } = new HashSet<PayrollEntry>(); 
}
