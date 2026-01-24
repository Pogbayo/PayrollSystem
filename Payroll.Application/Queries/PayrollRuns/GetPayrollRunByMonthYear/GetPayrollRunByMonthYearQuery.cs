using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.PayrollRun;

namespace Payroll.Application.Queries.PayrollRuns.GetPayrollRunByMonthYear
{
    public record GetPayrollRunByMonthYearQuery(int Month, int Year) : IRequest<ApiResponse<PayrollRunDto>>;
}
