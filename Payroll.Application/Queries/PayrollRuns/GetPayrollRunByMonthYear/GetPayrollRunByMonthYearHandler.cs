using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.PayrollEntry;
using Payroll.Application.Dtos.PayrollRun;
using Payroll.Application.Interfaces.IRepository;

namespace Payroll.Application.Queries.PayrollRuns.GetPayrollRunByMonthYear
{
    public class GetPayrollRunByMonthYearHandler : IRequestHandler<GetPayrollRunByMonthYearQuery, ApiResponse<PayrollRunDto>>
    {
        private readonly IPayrollRunRepository _repository;

        public GetPayrollRunByMonthYearHandler(IPayrollRunRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<PayrollRunDto>> Handle(GetPayrollRunByMonthYearQuery request, CancellationToken cancellationToken)
        {
            var run = await _repository.GetByMonthYearAsync(request.Month, request.Year);

            if (run == null)
                return ApiResponse<PayrollRunDto>.Fail("PayrollRun not found");

            var dto = new PayrollRunDto
            {
                Id = run.Id,
                Month = run.Month,
                Year = run.Year,
                Status = run.Status,
                ProcessedAt = run.ProcessedAt,
                PayrollEntries = run.PayrollEntries.Select(e => new PayrollEntryDto
                {
                    Id = e.Id,
                    EmployeeId = e.EmployeeId,
                    GrossPay = e.GrossPay,
                    CreatedAt = e.CreatedAt,
                }).ToList()
            };

            return ApiResponse<PayrollRunDto>.Ok(dto);
        }
    }
}
