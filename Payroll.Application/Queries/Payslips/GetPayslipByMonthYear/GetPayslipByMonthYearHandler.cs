using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.PayslipDto;
using Payroll.Application.Interfaces.IRepository;

namespace Payroll.Application.Queries.Payslips.GetPayslipByMonthYear
{
    public class GetPayslipByMonthYearHandler : IRequestHandler<GetPayslipByMonthYearQuery, ApiResponse<PayslipDto>>
    {
        private readonly IPayslipRepository _repository;

        public GetPayslipByMonthYearHandler(IPayslipRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<PayslipDto>> Handle(GetPayslipByMonthYearQuery request, CancellationToken cancellationToken)
        {
            var payslip = await _repository.GetByMonthYearAsync(request.Month, request.Year);

            if (payslip == null)
                return ApiResponse<PayslipDto>.Fail("Payslip not found for the given month and year");

            var dto = new PayslipDto
            {
                Id = payslip.Id,
                PayrollEntryId = payslip.PayrollEntryId,
                EmployeeId = payslip.EmployeeId,
                IssuedDate = payslip.IssuedDate,
                EmployeeName = payslip.Employee?.FirstName,
                Grosspay = payslip.PayrollEntry?.GrossPay,
                Month = payslip.PayrollEntry?.PayrollRun?.Month,
                Year = payslip.PayrollEntry?.PayrollRun?.Year
            };

            return ApiResponse<PayslipDto>.Ok(dto);
        }
    }
}
