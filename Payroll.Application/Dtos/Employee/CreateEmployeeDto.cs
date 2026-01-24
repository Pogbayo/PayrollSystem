namespace Payroll.Application.Dtos.Employee
{
    public class CreateEmployeeDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required decimal BaseSalary { get; set; }
        public required string BankAccountNumber { get; set; }
    }
}
