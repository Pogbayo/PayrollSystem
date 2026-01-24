using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.PayslipDto;
using Payroll.Application.Interfaces.IRepository;

namespace Payroll.Application.Queries.Payslips.GetPaySlipsById
{
    public class GetPayslipByIdHandler : IRequestHandler<GetPayslipByIdQuery, ApiResponse<PayslipDto>>
    {
        private readonly IPayslipRepository _repository;

        public GetPayslipByIdHandler(IPayslipRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<PayslipDto>> Handle(GetPayslipByIdQuery request, CancellationToken cancellationToken)
        {
            var payslip = await _repository.GetByIdAsync(request.Id);

            if (payslip == null)
                return ApiResponse<PayslipDto>.Fail("Payslip not found");

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
