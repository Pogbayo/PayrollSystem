using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.Employee;
using Payroll.Application.Interfaces.IRepository;

namespace Payroll.Application.Queries.Employees.GetAllEmployees
{
    public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, ApiResponse<List<EmployeeDto>>>
    {
        private readonly IEmployeeRepository _repository;

        public GetAllEmployeesHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<List<EmployeeDto>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _repository.GetAllAsync();

            if (employees == null || !employees.Any())
                return ApiResponse<List<EmployeeDto>>.Fail("No employees found");

            var dtos = employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName!,
                LastName = e.LastName!,
                Email = e.Email
            }).ToList();

            return ApiResponse<List<EmployeeDto>>.Ok(dtos);
        }
    }

}
