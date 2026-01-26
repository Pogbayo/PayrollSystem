using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.Employee;

namespace Payroll.Application.Queries.Employees.GetEmployeeById
{
  public record GetEmployeeByIdQuery(Guid EmployeeId) : IRequest<ApiResponse<EmployeeDto>>;
}
