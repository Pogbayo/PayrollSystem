using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.PayslipDto;
using Payroll.Application.Interfaces.IRepository;

namespace Payroll.Application.Commands.Payslips.CreatePayslip
{
    public class CreatePayslipHandler : IRequestHandler<CreatePayslipCommand, ApiResponse<PayslipDto>>
    {
        private readonly IPayslipRepository _repository;

        public CreatePayslipHandler(IPayslipRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<PayslipDto>> Handle(CreatePayslipCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Payslip;

            var payslip = new Payslip
            {
                Id = Guid.NewGuid(),
                PayrollEntryId = dto.PayrollEntryId,
                EmployeeId = dto.EmployeeId,
                IssuedDate = dto.IssuedDate
            };

            await _repository.AddAsync(payslip);

            var resultDto = new PayslipDto
            {
                Id = payslip.Id,
                PayrollEntryId = payslip.PayrollEntryId,
                EmployeeId = payslip.EmployeeId,
                IssuedDate = payslip.IssuedDate
            };

            return ApiResponse<PayslipDto>.Ok(resultDto);
        }
    }
}
