using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.PayrollRun;


namespace Payroll.Application.Queries.PayrollRuns.GetAllPayrollRuns
{
    public record GetAllPayrollRunsQuery() : IRequest<ApiResponse<IEnumerable<PayrollRunDto>>>;
}
