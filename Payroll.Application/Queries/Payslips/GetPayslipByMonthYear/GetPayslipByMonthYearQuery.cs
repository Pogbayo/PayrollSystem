using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.PayslipDto;

namespace Payroll.Application.Queries.Payslips.GetPayslipByMonthYear
{
    public record GetPayslipByMonthYearQuery(int Month, int Year) : IRequest<ApiResponse<PayslipDto>>;

}
