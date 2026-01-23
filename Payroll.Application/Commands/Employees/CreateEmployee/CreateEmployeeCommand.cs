using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.EmployeeDto;

namespace Payroll.Application.Commands.Employees.CreateEmployee
{
    public record CreateEmployeeCommand(CreateEmployeeDto Employee) : IRequest<ApiResponse<EmployeeDto>>;
}
