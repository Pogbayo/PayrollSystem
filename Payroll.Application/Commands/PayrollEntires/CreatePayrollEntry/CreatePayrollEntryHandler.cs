using MediatR;
using Payroll.Application.Commands.PayrollEntires.CreatePayrollEntry;
using Payroll.Application.Common;
using Payroll.Application.Dtos.PayrollEntry;
using Payroll.Application.Interfaces.IRepository;

namespace Payroll.Application.Commands.PayrollEntries.CreatePayrollEntry
{
    public class CreatePayrollEntryHandler : IRequestHandler<CreatePayrollEntryCommand, ApiResponse<PayrollEntryDto>>
    {
        private readonly IPayrollEntryRepository _repository;

        public CreatePayrollEntryHandler(IPayrollEntryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<PayrollEntryDto>> Handle(CreatePayrollEntryCommand request, CancellationToken cancellationToken)
        {
            var dto = request.PayrollEntry;

            var entry = new PayrollEntry
            {
                Id = Guid.NewGuid(),
                EmployeeId = dto.EmployeeId,
                GrossPay = dto.GrossPay,
                CreatedAt = dto.CreatedAt,
            };

            await _repository.AddAsync(entry);

            var resultDto = new PayrollEntryDto
            {
                Id = entry.Id,
                EmployeeId = entry.EmployeeId,
                GrossPay = entry.GrossPay,
                CreatedAt = entry.CreatedAt,
            };

            return ApiResponse<PayrollEntryDto>.Ok(resultDto);
        }
    }
}
