using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.PayrollEntry;
using Payroll.Application.Interfaces.IRepository;

namespace Payroll.Application.Queries.PayrollEntries.GetPayrollEntriesByEmployeeId
{
    public class GetPayrollEntriesByEmployeeIdHandler : IRequestHandler<GetPayrollEntriesByEmployeeIdQuery, ApiResponse<IEnumerable<PayrollEntryDto>>>
    {
        private readonly IPayrollEntryRepository _repository;

        public GetPayrollEntriesByEmployeeIdHandler(IPayrollEntryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<IEnumerable<PayrollEntryDto>>> Handle(GetPayrollEntriesByEmployeeIdQuery request, CancellationToken cancellationToken)
        {
            var entries = await _repository.GetByEmployeeIdAsync(request.EmployeeId);

            var dtos = entries.Select(entry => new PayrollEntryDto
            {
                Id = entry.Id,
                EmployeeId = entry.EmployeeId,
                GrossPay = entry.GrossPay,
                CreatedAt = entry.CreatedAt,
            });

            return ApiResponse<IEnumerable<PayrollEntryDto>>.Ok(dtos);
        }
    }
}
