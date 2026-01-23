using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.EmployeeDto;
using Payroll.Application.Interfaces.IRepository;


namespace Payroll.Application.Queries.Employees.GetEmployeeById
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, ApiResponse<EmployeeDto>>
    {
        private readonly IEmployeeRepository _repository;

        public GetEmployeeByIdHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<EmployeeDto>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetByIdAsync(request.EmployeeId);

            if (employee == null)
                return ApiResponse<EmployeeDto>.Fail("Employee not found");

            var dto = new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName!,
                LastName = employee.LastName!,
                Email = employee.Email!
            };

            return ApiResponse<EmployeeDto>.Ok(dto);
        }
    }

}
