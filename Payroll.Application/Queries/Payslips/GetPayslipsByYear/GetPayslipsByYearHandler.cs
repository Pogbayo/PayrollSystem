using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.PayslipDto;
using Payroll.Application.Interfaces.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Payroll.Application.Queries.Payslips.GetPayslipsByYear
{
    public class GetPayslipsByYearHandler : IRequestHandler<GetPayslipsByYearQuery, ApiResponse<IEnumerable<PayslipDto>>>
    {
        private readonly IPayslipRepository _repository;

        public GetPayslipsByYearHandler(IPayslipRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<IEnumerable<PayslipDto>>> Handle(GetPayslipsByYearQuery request, CancellationToken cancellationToken)
        {
            var payslips = await _repository.GetByYearAsync(request.Year);

            if (!payslips.Any())
                return ApiResponse<IEnumerable<PayslipDto>>.Fail("No payslips found for the given year");

            var dtos = payslips.Select(p => new PayslipDto
            {
                Id = p.Id,
                PayrollEntryId = p.PayrollEntryId,
                EmployeeId = p.EmployeeId,
                IssuedDate = p.IssuedDate,
                EmployeeName = p.Employee?.FirstName,
                Grosspay = p.PayrollEntry?.GrossPay,
                Month = p.PayrollEntry?.PayrollRun?.Month,
                Year = p.PayrollEntry?.PayrollRun?.Year
            });

            return ApiResponse<IEnumerable<PayslipDto>>.Ok(dtos);
        }
    }
}
