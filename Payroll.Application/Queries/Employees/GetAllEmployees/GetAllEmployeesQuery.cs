using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.Employee;

namespace Payroll.Application.Queries.Employees.GetAllEmployees
{
    public record GetAllEmployeesQuery() : IRequest<ApiResponse<List<EmployeeDto>>>;
}
