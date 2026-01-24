using FluentValidation;
using Payroll.Application.Commands.PayrollRuns.CreatePayrollRun;

namespace Payroll.Application.Validators.PayrollRuns
{
    public class CreatePayrollRunValidator : AbstractValidator<CreatePayrollRunCommand>
    {
        public CreatePayrollRunValidator()
        {
            RuleFor(x => x.PayrollRun.Month)
                .InclusiveBetween(1, 12)
                .WithMessage("Month must be between 1 and 12");

            RuleFor(x => x.PayrollRun.Year)
                .GreaterThan(2000)
                .WithMessage("Year must be valid");

            RuleFor(x => x.PayrollRun.Status)
                .IsInEnum()
                .WithMessage("Status is required");

            RuleFor(x => x.PayrollRun.ProcessedAt)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Processed date cannot be in the future");
        }
    }
}
