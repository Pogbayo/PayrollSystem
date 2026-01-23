using MediatR;
using Payroll.Application.Common;
using Payroll.Application.Dtos.EmployeeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Application.Queries.Employees.GetEmployeeById
{
  public record GetEmployeeByIdQuery(Guid EmployeeId) : IRequest<ApiResponse<EmployeeDto>>;
}
