using FluentValidation;
using Payroll.Application.Commands.Payslips.CreatePayslip;

namespace Payroll.Application.Validators.Payslips
{
    public class CreatePayslipValidator : AbstractValidator<CreatePayslipCommand>
    {
        public CreatePayslipValidator()
        {
            RuleFor(x => x.Payslip.PayrollEntryId)
                .NotEmpty().WithMessage("PayrollEntryId is required");

            RuleFor(x => x.Payslip.EmployeeId)
                .NotEmpty().WithMessage("EmployeeId is required");

            RuleFor(x => x.Payslip.IssuedDate)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Issued date cannot be in the future");
        }
    }
}
