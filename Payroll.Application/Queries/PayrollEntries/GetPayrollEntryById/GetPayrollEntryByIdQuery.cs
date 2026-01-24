using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.PayrollEntry;

namespace Payroll.Application.Queries.PayrollEntries.GetPayrollEntryById
{
    public record GetPayrollEntryByIdQuery(Guid Id) : IRequest<ApiResponse<PayrollEntryDto>>;

}
