using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.PayslipDto;

namespace Payroll.Application.Commands.Payslips.CreatePayslip
{
    public record CreatePayslipCommand(PayslipDto Payslip) : IRequest<ApiResponse<PayslipDto>>;
}
