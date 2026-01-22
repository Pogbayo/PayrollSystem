using Payroll.Application.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Infrastructure.Repositories
{
    public class AttendanceRecordRepository : IAttendanceRecordRepository
    {
        public Task AddAsync(AttendanceRecord entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AttendanceRecord>> GetByEmployeeIdAsync(Guid employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
