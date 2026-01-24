using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.PayslipDto;
using Payroll.Application.Interfaces.IRepository;

namespace Payroll.Application.Queries.Payslips.GetAllPayslips
{
    public class GetAllPayslipsHandler : IRequestHandler<GetAllPayslipsQuery, ApiResponse<IEnumerable<PayslipDto>>>
    {
        private readonly IPayslipRepository _repository;

        public GetAllPayslipsHandler(IPayslipRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<IEnumerable<PayslipDto>>> Handle(GetAllPayslipsQuery request, CancellationToken cancellationToken)
        {
            var payslips = await _repository.GetAllAsync();

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
