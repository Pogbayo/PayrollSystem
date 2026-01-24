using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.PayrollEntry;
using Payroll.Application.Interfaces.IRepository;

namespace Payroll.Application.Queries.PayrollEntries.GetPayrollEntryById
{
    public class GetPayrollEntryByIdHandler : IRequestHandler<GetPayrollEntryByIdQuery, ApiResponse<PayrollEntryDto>>
    {
        private readonly IPayrollEntryRepository _repository;

        public GetPayrollEntryByIdHandler(IPayrollEntryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<PayrollEntryDto>> Handle(GetPayrollEntryByIdQuery request, CancellationToken cancellationToken)
        {
            var entry = await _repository.GetByIdAsync(request.Id);

            if (entry == null)
                return ApiResponse<PayrollEntryDto>.Fail("PayrollEntry not found");

            var dto = new PayrollEntryDto
            {
                Id = entry.Id,
                EmployeeId = entry.EmployeeId,
                GrossPay = entry.GrossPay,
                CreatedAt = entry.CreatedAt,
            };

            return ApiResponse<PayrollEntryDto>.Ok(dto);
        }
    }
}
