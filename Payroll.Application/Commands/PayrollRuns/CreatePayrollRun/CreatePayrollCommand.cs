using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.PayrollRun;


namespace Payroll.Application.Commands.PayrollRuns.CreatePayrollRun
{
    public record CreatePayrollRunCommand(PayrollRunDto PayrollRun)
          : IRequest<ApiResponse<PayrollRunDto>>;
}
