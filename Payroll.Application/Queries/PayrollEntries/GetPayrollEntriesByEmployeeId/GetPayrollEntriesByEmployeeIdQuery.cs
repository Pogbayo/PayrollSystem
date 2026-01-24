using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.PayrollEntry;

namespace Payroll.Application.Queries.PayrollEntries.GetPayrollEntriesByEmployeeId
{
    public record GetPayrollEntriesByEmployeeIdQuery(Guid EmployeeId) : IRequest<ApiResponse<IEnumerable<PayrollEntryDto>>>;
}
