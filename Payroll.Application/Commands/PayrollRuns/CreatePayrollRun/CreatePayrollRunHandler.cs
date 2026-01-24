using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.PayrollEntry;
using Payroll.Application.Dtos.PayrollRun;
using Payroll.Application.Interfaces.IRepository;

namespace Payroll.Application.Commands.PayrollRuns.CreatePayrollRun
{
    public class CreatePayrollRunHandler : IRequestHandler<CreatePayrollRunCommand, ApiResponse<PayrollRunDto>>
    {
        private readonly IPayrollRunRepository _repository;

        public CreatePayrollRunHandler(IPayrollRunRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<PayrollRunDto>> Handle(CreatePayrollRunCommand request, CancellationToken cancellationToken)
        {
            var dto = request.PayrollRun;

            var payrollRun = new PayrollRun
            {
                Id = Guid.NewGuid(),
                Month = dto.Month,
                Year = dto.Year,
                Status = dto.Status,
                ProcessedAt = dto.ProcessedAt,
                PayrollEntries = new List<PayrollEntry>() 
            };

            await _repository.AddAsync(payrollRun);

            var resultDto = new PayrollRunDto
            {
                Id = payrollRun.Id,
                Month = payrollRun.Month,
                Year = payrollRun.Year,
                Status = payrollRun.Status,
                ProcessedAt = payrollRun.ProcessedAt,
                PayrollEntries = new List<PayrollEntryDto>() 
            };

            return ApiResponse<PayrollRunDto>.Ok(resultDto);
        }
    }
}
