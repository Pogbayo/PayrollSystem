using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.PayrollEntryDto;

namespace Payroll.Application.Commands.PayrollEntires.CreatePayrollEntry
{
    public record CreatePayrollEntryCommand(CreatePayrollEntryDto PayrollEntry)
       : IRequest<ApiResponse<PayrollEntryDto>>;
}
