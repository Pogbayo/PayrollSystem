using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.Employee;
using Payroll.Application.Interfaces.IRepository;

namespace Payroll.Application.Commands.Employees.CreateEmployee
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, ApiResponse<EmployeeDto>>
    {
        private readonly IEmployeeRepository _repository;

        public CreateEmployeeHandler(IEmployeeRepository repository)
        {
            _repository = repository; 
        }

        public async Task<ApiResponse<EmployeeDto>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Employee;

            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                BaseSalary = dto.BaseSalary,
                BankAccountNumber = dto.BankAccountNumber
            };

            await _repository.AddAsync(employee);

            var resultDto = new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email
            };

            return ApiResponse<EmployeeDto>.Ok(resultDto);
        }
    }
}
