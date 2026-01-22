using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Application.Interfaces.IService
{
    public interface IAttendanceRecordService
    {
        Task<IEnumerable<AttendanceRecord>> GetByEmployeeIdAsync(Guid employeeId);
        Task<Guid> AddAsync(AttendanceRecord entity);
    }
}
