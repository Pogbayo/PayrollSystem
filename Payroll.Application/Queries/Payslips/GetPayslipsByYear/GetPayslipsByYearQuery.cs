using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.PayslipDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Application.Queries.Payslips.GetPayslipsByYear
{
    public record GetPayslipsByYearQuery(int Year) : IRequest<ApiResponse<IEnumerable<PayslipDto>>>;
}
