using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.PayslipDto;

namespace Payroll.Application.Queries.Payslips.GetAllPayslips
{
    public record GetAllPayslipsQuery() : IRequest<ApiResponse<IEnumerable<PayslipDto>>>;

}
