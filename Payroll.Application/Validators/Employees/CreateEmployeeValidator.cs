using Payroll.Application.Commands.Employees.CreateEmployee;

namespace Payroll.Application.Validators.Employees
{
    using FluentValidation;

    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.Employee.FirstName).NotEmpty().WithMessage("First name is required");
            RuleFor(x => x.Employee.LastName).NotEmpty().WithMessage("Last name is required");
            RuleFor(x => x.Employee.Email).NotEmpty().EmailAddress().WithMessage("Valid email is required");
            RuleFor(x => x.Employee.BaseSalary).GreaterThan(0).WithMessage("Base salary must be greater than 0");
        }
    }
}
