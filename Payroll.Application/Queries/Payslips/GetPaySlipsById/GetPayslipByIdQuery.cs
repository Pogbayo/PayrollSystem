using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.PayslipDto;


namespace Payroll.Application.Queries.Payslips.GetPaySlipsById
{
    public record GetPayslipByIdQuery(Guid Id) : IRequest<ApiResponse<PayslipDto>>;

}
