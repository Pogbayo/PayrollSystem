using FluentValidation;
using Payroll.Application.Commands.PayrollEntires.CreatePayrollEntry;

namespace Payroll.Application.Validators.PayrollEntries
{
    public class CreatePayrollEntryValidator : AbstractValidator<CreatePayrollEntryCommand>
    {
        public CreatePayrollEntryValidator()
        {
            RuleFor(x => x.PayrollEntry.EmployeeId)
                .NotEmpty().WithMessage("EmployeeId is required");

            RuleFor(x => x.PayrollEntry.GrossPay)
                .GreaterThan(0).WithMessage("Amount must be greater than 0");

            RuleFor(x => x.PayrollEntry.CreatedAt)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Date cannot be in the future");
        }
    }
}
