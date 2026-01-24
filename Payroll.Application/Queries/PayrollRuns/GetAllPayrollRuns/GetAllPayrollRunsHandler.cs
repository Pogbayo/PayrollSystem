using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.PayrollEntry;
using Payroll.Application.Dtos.PayrollRun;
using Payroll.Application.Interfaces.IRepository;

namespace Payroll.Application.Queries.PayrollRuns.GetAllPayrollRuns
{
    public class GetAllPayrollRunsHandler : IRequestHandler<GetAllPayrollRunsQuery, ApiResponse<IEnumerable<PayrollRunDto>>>
    {
        private readonly IPayrollRunRepository _repository;

        public GetAllPayrollRunsHandler(IPayrollRunRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<IEnumerable<PayrollRunDto>>> Handle(GetAllPayrollRunsQuery request, CancellationToken cancellationToken)
        {
            var runs = await _repository.GetAllAsync();

            var dtos = runs.Select(run => new PayrollRunDto
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
            });

            return ApiResponse<IEnumerable<PayrollRunDto>>.Ok(dtos);
        }
    }
}
